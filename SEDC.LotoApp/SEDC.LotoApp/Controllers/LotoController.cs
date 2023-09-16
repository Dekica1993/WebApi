using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Loto3000App.DataAcces.EntityImplementation;
using SEDC.Loto3000App.DTOs;
using SEDC.Loto3000App.Services.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.Loto3000App.Controllers
{
    [Route("api/[controller]")]
    public class LotoController : Controller
    {
        private readonly ILotoService _lotoService;

        public LotoController(ILotoService lotoService)
        {
            _lotoService = lotoService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var UserId = User.FindFirstValue("UserId");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sistem error occured, contact admin ");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var lotoDto = _lotoService.GetById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sistem error occured, contact admin ");

            }
        }

        [HttpPost]
        public IActionResult AddWinner([FromBody] AddLotoDto addLotoDto)
        {
            try
            {
                _lotoService.AddWinner(addLotoDto);
                return StatusCode(201, "Winner added");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sistem error occured, contact admin ");
            }
        }

        [HttpPut]
        public IActionResult UpdateWinner([FromBody] UpdateLotoDto updateLotoDto)
        {
            try
            {
                _lotoService.UpdateWinner(updateLotoDto);
                return StatusCode(201, "Winner is updated");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sistem error occured, contact admin ");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWinner([FromRoute] int id)
        {
            try
            {
                _lotoService.DeleteWinner(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sistem error occured, contact admin ");
            }
        }
    }
}

