using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    FuncionarioController() {}

    [HttpGet]
    public async Task<IActionResult> GetAll() { }

    [HttpGet]
    public async Task<IActionResult> GetById(int id) {}
}