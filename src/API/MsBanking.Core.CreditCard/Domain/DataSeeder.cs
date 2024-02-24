using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.CreditCard.Domain
{
    public class DataSeeder
    {

        public static void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CreditCardDbContext>();

                if (context == null)
                    return;

                context.Database.Migrate();
                context.Database.EnsureCreated();


            }
        }
    }   
}
