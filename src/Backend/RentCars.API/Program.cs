using RentCars.API.Filters;
using RentCars.API.Middleware;
using RentCars.Application;
using RentCars.Infrastructure;
using RentCars.Infrastructure.Migrations;
using RentCars.Infrastructure.Extensions;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LanguageMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateDatabase();

app.Run();

void MigrateDatabase()
{
    if (builder.Configuration.IsUnitTestEnvironment())
        return;

    var connectionString = builder.Configuration.ConnectionString();

    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigrations.Migrate(connectionString, serviceScope.ServiceProvider);
}

public partial class Program
{

}
