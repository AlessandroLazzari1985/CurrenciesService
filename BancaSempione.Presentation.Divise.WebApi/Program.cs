using BancaSempione.Presentation.Divise.WebApi;
using BancaSempione.Presentation.Divise.WebApi.Controllers.OData.Configurations;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using OData.Swagger.Services;


var builder = WebApplication.CreateBuilder(args);

// Read configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers().RegisterOdata("odata");
builder.Services.Register_BancaSempione_Presentation_Divise_WebApi(builder.Configuration.Get<WebApiAppSettings>()!);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOdataSwaggerSupport();

var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(() =>
{
    var server = app.Services.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();

    if (addressFeature?.Addresses == null) return;
    addressFeature.Addresses.ToList().ForEach(address => Console.WriteLine($"Application started on: {address}"));
});


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//});

app.Run();
