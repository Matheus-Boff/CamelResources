using back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using back.Models.Enums;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet("notebook")]
        public async Task<IActionResult> GetAvailableNotebooks([FromQuery] DateTime date)
        {
            Console.WriteLine(date);
            Console.WriteLine(date.ToString());
            var result = await _service.GetAvaiableResource(date, ResourceType.Notebook);
            return Ok(result);
        }

        [HttpGet("lab")]
        public async Task<IActionResult> GetAvailableLabs([FromQuery] DateTime date)
        {
            var result = await _service.GetAvaiableResource(date, ResourceType.Laboratorio);
            return Ok(result);
        }

        [HttpGet("sala")]
        public async Task<IActionResult> GetAvailableSalas([FromQuery] DateTime date)
        {
            var result = await _service.GetAvaiableResource(date, ResourceType.Sala);
            return Ok(result);
        }
    }
}