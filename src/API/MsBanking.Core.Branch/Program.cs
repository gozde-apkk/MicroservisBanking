using Microsoft.EntityFrameworkCore;
using MsBanking.Common.Dto;
using MsBanking.Core.Branch;
using MsBanking.Core.Branch.Api;
using MsBanking.Core.Branch.Domain;
using MsBanking.Core.Branch.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//sql server
builder.Services.AddDbContext<BranchDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//resolve service
builder.Services.AddScoped<IBranchService, BranchService>();


//automapper
builder.Services.AddAutoMapper(typeof(BranchProfile));


//redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "MsBanking.Core.Branch";
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.MapGroup("api/vı/")
    .WithTags("Branch")
    .MapBranchApi();

DataSeeder.Seed(app);

app.Run();
