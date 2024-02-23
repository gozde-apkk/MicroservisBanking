using Microsoft.AspNetCore.Http.HttpResults;
using MsBanking.Common.Dto;
using MsBanking.Common.Entity;
using MsBanking.Core.Service;
using Serilog;
using System.Text.Json;

namespace MsBanking.Core.Apis
{
    public static class CustomerApi
    {
        public static IEndpointRouteBuilder MapCustomerApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/customer", GetAllCustomers);
            app.MapGet("/customer/{id}", GetCustomer);
            app.MapPost("/customer", CreateCustomer);
            app.MapPut("/customer/{id}", UpdateCustomer);
            app.MapDelete("/customer/{id}", DeleteCustomer);
            return app;
        }

        private static async Task<Results<Ok<List<CustomerResponseDto>>, NotFound>> GetAllCustomers(ICustomerService service)
        {
            Log.Information("Called Get all customers");

            var customers = await service.GetCustomers();
            if (!customers.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(customers);
        }

        private static async Task<Results<Ok<CustomerResponseDto>, NotFound>> GetCustomer(ICustomerService service, string id)
        {
            Log.Information("Called Get customer by id, {id}", id);
            var customer = await service.GetCustomer(id);
            if (customer == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(customer);
        }

        private static async Task<Results<Ok<CustomerResponseDto>, BadRequest>> CreateCustomer(ICustomerService service, CustomerDto customer)
        {
            var serialized = JsonSerializer.Serialize(customer);
            Log.Logger.Information("Called Create customer, @{customer}", serialized);
            var createdCustomer = await service.CreateCustomer(customer);
            return TypedResults.Ok(createdCustomer);
        }

        private static async Task<Results<Ok<CustomerResponseDto>, NotFound>> UpdateCustomer(ICustomerService service, string id, CustomerDto customer)
        {
            Log.Information("Called Update customer, {id}", id);
            var updatedCustomer = await service.UpdateCustomer(id, customer);
            if (updatedCustomer == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(updatedCustomer);
        }

        private static async Task<Results<Ok, NotFound>> DeleteCustomer(ICustomerService service, string id)
        {
            Log.Information("Called Delete customer, {id}", id);
            var deleted = await service.DeleteCustomer(id);
            if (!deleted)
                return TypedResults.NotFound();
            return TypedResults.Ok();
        }
    }
}
