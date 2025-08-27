using back.DTOs;
using back.Models;
using back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlocacaoController : ControllerBase
    {
        private readonly IAlocacaoService _service;

        public AlocacaoController(IAlocacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alocacoes = await _service.GetAllAsync();
            return Ok(alocacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alocacao = await _service.GetByIdAsync(id);
            return Ok(alocacao);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlocacaoCreateDTO alocacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(alocacaoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotebookUpdateDTO notebookDto)
        {
            throw new NotImplementedException();
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, notebookDto);
            return Ok();*/
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
            /*await _service.DeleteAsync(id);
            return Ok();*/
        }
    }
}