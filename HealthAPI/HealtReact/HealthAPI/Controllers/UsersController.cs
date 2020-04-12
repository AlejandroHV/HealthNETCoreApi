using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAPI.Context;
using HealthAPI.DTOS;
using HealthAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {

        private readonly HealthContext _context;
       

        public UsersController(HealthContext _healthContext)
        {
            _context = _healthContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
           var patients =  _context.Patients.ToList();

            return Ok(patients);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LoginUser([FromBody] Credentials credentials)
        {

            UserDTO userDTO = new UserDTO();
            if (credentials == null)
            {
                BadRequest();
            }
            
            var user = _context.Patients.FirstOrDefault(u => u.Email == credentials.Email && u.UserPassword == credentials.Password);
            if (user == null) 
            {
               return BadRequest();
            }
            IEnumerable<Appointment> appointments = _context.Appointments.Where(x => x.PatientId == user.Id).ToList();
            IEnumerable<int> sicknessIds = _context.PatientSicknesses.Where(x => x.PatientId == user.Id ).Select(x=> x.SicknessId);
            IEnumerable<Sickness> sicknesses = _context.Sicknesses.Where(x => sicknessIds.Contains(x.Id)).ToList();

             userDTO= mapUserDto(user, sicknesses, appointments);

            return Ok(userDTO);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO user)
        {

            UserDTO userDTO = new UserDTO();
            if (user == null || id== 0)
            {
                BadRequest();
            }

            try
            {
                var existantUser = _context.Patients.FirstOrDefault(u => u.Id == id);
                if (existantUser == null)
                {
                    return NotFound();
                }

                //TO DO.USE A DELTA
                existantUser.PhoneNumber = user.PhoneNumber;
                existantUser.Location = user.Location;
                existantUser.InsuranceName = user.InsuranceName;
                existantUser.Email = user.Email;
                existantUser.BirthDate = user.BirthDate;


                _context.Patients.Update(existantUser);
                int valuesSaved = _context.SaveChanges();
                if (valuesSaved > 0)
                {
                    IEnumerable<Appointment> appointments = _context.Appointments.Where(x => x.PatientId == existantUser.Id).ToList();
                    IEnumerable<int> sicknessIds = _context.PatientSicknesses.Where(x => x.PatientId == existantUser.Id).Select(x => x.SicknessId);
                    IEnumerable<Sickness> sicknesses = _context.Sicknesses.Where(x => sicknessIds.Contains(x.Id)).ToList();

                    userDTO = mapUserDto(existantUser, sicknesses, appointments);
                    return Ok(userDTO);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
            

          
        }


        private UserDTO mapUserDto(Patient user, IEnumerable<Sickness>  sicknesses, IEnumerable<Appointment> appointments ) {

            UserDTO userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Location = user.Location;
            userDTO.PhoneNumber = user.PhoneNumber;
            userDTO.Email = user.Email;
            userDTO.BirthDate = user.BirthDate;
            userDTO.InsuranceName = user.InsuranceName;
            userDTO.Appointsments = appointments;
            userDTO.Sicknesses = sicknesses;
            return userDTO;

        }

    }
}
