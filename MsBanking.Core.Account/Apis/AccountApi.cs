using Microsoft.AspNetCore.Http.HttpResults;
using MsBanking.Common.Dto;
using MsBanking.Core.Account.Services;

namespace MsBanking.Core.Account.Apis
{
    public static class AccountApi
    {

        public static IEndpointRouteBuilder MapAccountApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/account", GetAllAccounts);
            app.MapGet("/account/{id}", GetAccount);
            app.MapPost("/account", CreateAccount);
            return app;
        }

        private static async Task<Results<Ok<List<AccountResponseDto>>, NotFound>> GetAllAccounts(IAccountService service)
        {
            var accounts = await service.GetAccounts();
            if (!accounts.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(accounts);
        }

        private static async Task<Results<Ok<AccountResponseDto>, NotFound>> GetAccount(IAccountService service, int id)
        {
            var account = await service.GetAccount(id);
            if (account == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(account);
        }

        private static async Task<Results<Ok<AccountResponseDto>, BadRequest>> CreateAccount(IAccountService service, AccountDto account)
        {
            var createdAccount = await service.CreateAccount(account);
            return TypedResults.Ok(createdAccount);
        }

    
    }
}
