using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Repositories;
using BancaSempione.Presentation.Divise.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var appSettings = builder.Configuration.Get<AppSettings>();

// Add services to the container.
builder.Services.AddSingleton(appSettings!);
builder.Services.AddControllers();

builder.Services
    // Application


    // Infrastructure
    .Register_BancaSempione_Infrastructure_Repositories()
    .Register_BancaSempione_Infrastructure_Database(appSettings!.ConnectionStrings.DefaultConnection);

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
