using Microsoft.AspNetCore.Http.HttpResults;
using MsBanking.Common.Dto;
using MsBanking.Common.Entity;
using MsBanking.Core.Service;

namespace MsBanking.Core.Apis
{
    public static class CustomerApi
    {
        public static IEndpointRouteBuilder MapCustomerApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/customer", GetAllCustomers);
            app.MapGet("/customer/{id}", GetCustomer);
            app.MapPost("/customer", CreateCustomer);
            return app;
        }

      private static async Task<Results<Ok<List<Customer>>, NotFound>> GetAllCustomers(ICustomerService service)
        {
            var customers = await service.GetCustomers();
            if (!customers.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(customers);
        }

        private static async Task<Results<Ok<Customer>, NotFound>> GetCustomer(ICustomerService service, int id)
        {
            var customer = await service.GetCustomer(id);
            if (customer == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(customer);
        }

        private static async Task<Results<Ok<Customer>, NotFound>> CreateCustomer(ICustomerService service, Customer customer)
        {
            var newCustomer = await service.CreateCustomer(customer);
            return TypedResults.Ok(newCustomer);
        }
    }
}
