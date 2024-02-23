using MsBanking.Common.Dto;
using MsBanking.Core.Apis;
using MsBanking.Core.Domain;
using MsBanking.Core.Service;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("DatabaseOptions"));

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddAutoMapper(typeof(CustomerDtoProfile));

var app = builder.Build();

//serilog configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("log.txt")
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
    .CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/api/v1")
    .WithTags("Banking api v1")
    .MapCustomerApi();
app.Run();
