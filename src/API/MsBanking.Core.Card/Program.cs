
using Microsoft.EntityFrameworkCore;
using MsBanking.Core.Card.Domain;
using MsBanking.Core.Card.Domain.Dto;
using MsBanking.Core.Card.Services;


namespace MsBanking.Core.Card
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddScoped<ICardService, CardService>();
            //sql server
            builder.Services.AddDbContext<CardDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(CardDtoProfile));
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


            DataSeeder.Seed(app);
            app.Run();
        }
    }
}
