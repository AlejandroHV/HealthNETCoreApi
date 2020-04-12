using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAPI.Context;
using HealthAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthAPI.Controllers
{

    [EnableCors]
    [Route("WellnessPlans")]
    [ApiController]
    public class WellnessPlansController : ControllerBase
    {


        private readonly HealthContext _context;


        public WellnessPlansController(HealthContext _healthContext)
        {
            _context = _healthContext;
        }


        [HttpGet]
        public IActionResult GetWellnessPlans()
        {

            IEnumerable<WellnessPlan> wellnessPlans = _context.WellnessPlans.ToList();

            return Ok(wellnessPlans);

        }
    }
}