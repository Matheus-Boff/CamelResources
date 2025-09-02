using back.Data;
using back.Middleware;
using back.Repositories.Implementations;
using back.Repositories.Interfaces;
using back.Services.Implementations;
using back.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//criando a permissão para o front poder fazer requisições
builder.Services.AddCors(options =>
{
    options.AddPolicy("permissaoDeRequisicoesFront",
    policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

// Adicionar serviços de controller
builder.Services.AddControllers();

// Configuração do DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

builder.Services.AddScoped<INotebookRepository, NotebookRepository>();
builder.Services.AddScoped<INotebookService, NotebookService>();

builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<ISalaService, SalaService>();

builder.Services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
builder.Services.AddScoped<ILaboratorioService, LaboratorioService>();

builder.Services.AddScoped<IAlocacaoRepository, AlocacaoRepository>();
builder.Services.AddScoped<IAlocacaoService, AlocacaoService>();

builder.Services.AddScoped<IStatusService, StatusService>();

// --- Configuração do Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "API para gerenciamento de funcionários"
    });
});

var app = builder.Build();

// implementando a permissão para o front poder fazer requisições
app.UseCors("permissaoDeRequisicoesFront");

// Habilitar Swagger em desenvolvimento (pode habilitar em produção se quiser)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
        c.RoutePrefix = string.Empty; // Swagger abre na raiz
    });
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
