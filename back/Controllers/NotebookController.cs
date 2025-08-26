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
            try
            {
                var notebooks = await _service.GetAllAsync();

                return Ok(notebooks);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            } 
            catch (Exception)
            {
                return StatusCode(505, new { message = "Erro interno" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        { 
            try
            {
                var notebook = await _service.GetByIdAsync(id);
                return Ok(notebook);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno"});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Notebook notebook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("lalalala");
                    await _service.CreateAsync(notebook);
                    return Ok(notebook);
                }

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Notebook notebook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateAsync(id, notebook);
                    return Ok(notebook);
                }

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

