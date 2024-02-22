using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.Branch.Domain
{
    public static class DataSeeder
    {

        public static void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BranchDbContext>();

                if (context == null)
                    return;

                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Branches.Any())
                {
                    var branchList = new List<MsBanking.Common.Entity.Branch>()
                    {
                        new Common.Entity.Branch() { Code = 9019, Name = "Genel Merkez", CityId = 34, CountryId = 90 },
                        new Common.Entity.Branch() { Code = 9142, Name = "Zincirlikuyu", CityId = 34, CountryId = 90 },
                        new Common.Entity.Branch() { Code = 9080, Name = "Ege", CityId = 35, CountryId = 90 },
                    };

                    context.AddRange(branchList);
                    context.SaveChanges();
                }
            }
        }
    }
}
