using back.DTOs;
using back.Models;
using back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotebookController : ControllerBase
    {
        private readonly INotebookService _service;

        public NotebookController(INotebookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notebooks = await _service.GetAllAsync();
            return Ok(notebooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notebook = await _service.GetByIdAsync(id);
            return Ok(notebook);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotebookCreateDTO notebookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(notebookDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotebookUpdateDTO notebookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, notebookDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}