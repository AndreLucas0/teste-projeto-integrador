using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using api.Data;
using api.Interfaces.Repositories;
using api.Repositories;
using api.Interfaces.Services;
using api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BackEndAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BackEndAPIContext") ?? throw new InvalidOperationException("Connection string 'BackEndAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ILegalEntityRepository, LegalEntityRepository>();
builder.Services.AddScoped<ILegalEntityService, LegalEntityService>();
builder.Services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
builder.Services.AddScoped<INaturalPersonService, NaturalPersonService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
