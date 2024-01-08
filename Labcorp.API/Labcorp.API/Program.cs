using Labcorp.API.Data;
using Labcorp.API.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddSwaggerGen()
    .AddCors()
    .AddEndpointsApiExplorer()
    .AddRepositories(builder.Configuration)
    .AddBusinessLogic()
    .AddControllers();



var app = builder.Build();

// Seed Data
await SeedData.Initialize(app.Services);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
