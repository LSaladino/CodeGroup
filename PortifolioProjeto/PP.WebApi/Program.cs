using Microsoft.EntityFrameworkCore;
using PP.Data.Context;
using PP.Data.Repository;
using PP.Manager.Implementation;
using PP.Manager.Interfaces.Managers;
using PP.Manager.Interfaces.Repositories;
using PP.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//mapping using automapper
builder.Services.AddAutoMapperConfig();

// depency injection
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaManager, PessoaManager>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//database
// postgree
builder.Services.AddDbContext<MyDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnPG"));
});


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
