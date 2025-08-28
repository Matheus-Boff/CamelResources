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
            var notebooks = await _service.GetAvaiableResource(date, ResourceType.Notebook);
            return Ok(notebooks);
        }

        [HttpGet("lab")]
        public async Task<IActionResult> GetAvailableLabs([FromQuery] DateTime date)
        {
            var labs = await _service.GetAvaiableResource(date, ResourceType.Laboratorio);
            return Ok(labs);
        }

        [HttpGet("sala")]
        public async Task<IActionResult> GetAvailableSalas([FromQuery] DateTime date)
        {
            var salas = await _service.GetAvaiableResource(date, ResourceType.Sala);
            return Ok(salas);
        }

        [HttpGet("alocationsRange")]
        public async Task<IActionResult> GetAllocationsByDateRange([FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var alocacoes = await _service.GetResourcesByDateRange(startDate, endDate);
            return Ok(alocacoes);
        }
    }
}