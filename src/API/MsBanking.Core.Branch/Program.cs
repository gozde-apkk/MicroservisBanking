using Microsoft.EntityFrameworkCore;
using MsBanking.Common.Dto;
using MsBanking.Core.Branch;
using MsBanking.Core.Branch.Apis;
using MsBanking.Core.Branch.Domain;
using MsBanking.Core.Branch.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddAutoMapper(typeof(BranchProfile));
builder.Services.AddDbContext<BranchDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
var app = builder.Build();

app.MapGroup("/api/v1/")
    .WithTags("Core Banking Branch Api")
    .MapBranchApi();    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DataSeeder.Seed(app);

app.Run();
