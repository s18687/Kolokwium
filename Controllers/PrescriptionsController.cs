using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{

    [ApiController]
    [Route("api/[prescriptions]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionsDbService _dbService;

        [HttpGet("{id}")]
        

        [HttpPost]
        public IActionResult CreatePerscription(NewPrescriptions newPre)
        {
            var pre = _dbService.CreatePerscription(newPre);
            if(pre == null)
            {
                return BadRequest();
            }
            return Created("", pre);
        }
    }
}