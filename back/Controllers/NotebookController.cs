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
        public async Task<IActionResult> Create([FromBody] Notebook notebook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(notebook);
            return Ok(notebook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Notebook notebook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, notebook);
            return Ok(notebook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}