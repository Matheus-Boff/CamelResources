using back.DTOs;
using back.Models;
using back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratorioController : ControllerBase
    {
        private readonly ILaboratorioService _service;

        public LaboratorioController(ILaboratorioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var labs = await _service.GetAllAsync();
            return Ok(labs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lab = await _service.GetByIdAsync(id);
            return Ok(lab);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LaboratorioUpdateDTO labDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, labDto);
            return Ok(labDto);
        }
    }
}