using Desaffio.Context;
using Desaffio.Integracao;
using Desaffio.Integracao.Interfaces;
using Desaffio.Integracao.Refit;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ConsultaContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ConexaoConsultaAlunosCursos")
        )
);
//Configuracao do Via Cep Integraçao
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

//Configuracoes Dependencia do Refite para qual api ele vai bater com a rota "https://viacep.com.br".
builder.Services
    .AddRefitClient<IViaCepIntegracaoRefit>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://viacep.com.br");
    });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
