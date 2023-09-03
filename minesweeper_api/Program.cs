using Domain.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepositoryDbContext>(options =>
    options.UseCosmos(builder.Configuration["AzureCDB:Endpoint"], builder.Configuration["AzureCDB:Key"], builder.Configuration["AzureCDB:Db"]));

builder.Services.AddScoped<IServiceWrapper, ServiceWrapper>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddMvc().AddApplicationPart(typeof(Presentation.Controllers.GameInfoController).Assembly).AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Minesweeper API", Version = "v1" }));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minesweeper API v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();