using Microsoft.AspNetCore.Http.HttpResults;
using MsBanking.Common.Dto;
using MsBanking.Core.Account.Domain.Dto;
using MsBanking.Core.Account.Services;
using Serilog;

namespace MsBanking.Core.Account.Apis
{
    public static class AccountApi
    {
        public static IEndpointRouteBuilder MapAccountApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/account", GetAllAccounts);
            app.MapGet("/account/{id}", GetAccount);
            app.MapPost("/account", CreateAccount);

            app.MapPost("acctran", CreateAccountTransaction);
            app.MapGet("acctranhistory/{accountId}", GetAccountTransactionHistory);
            return app;
        }

        private static async Task<Results<Ok<List<AccountResponseDto>>, NotFound>> GetAllAccounts(IAccountService service)
        {
            Log.Information("Called GetAllAccounts");
            var accounts = await service.GetAccounts();
            if (!accounts.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(accounts);
        }

        private static async Task<Results<Ok<AccountResponseDto>, NotFound>> GetAccount(IAccountService service, int id)
        {
            Log.Information("Called GetAccount param: {id}", id);
            var account = await service.GetAccount(id);
            if (account == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(account);
        }

        private static async Task<Results<Ok<AccountResponseDto>, BadRequest>> CreateAccount(IAccountService service, AccountDto account)
        {
            Log.Information("Called CreateAccount param: {account}", account);
            var createdAccount = await service.CreateAccount(account);
            return TypedResults.Ok(createdAccount);
        }

        private static async Task<Results<Ok<AccountTransactionResponseDto>, BadRequest>> CreateAccountTransaction(IAccountTransactionService service, AccountTransactionRequestDto accountTransaction)
        {
            Log.Information("Called CreateAccountTransaction param: {accountTransaction}", accountTransaction);
            var createdAccountTransaction = await service.CreateAccountTransaction(accountTransaction);
            return TypedResults.Ok(createdAccountTransaction);
        }

        private static async Task<Results<Ok<List<AccountTransactionRequestDto>>, NotFound>> GetAccountTransactionHistory(IAccountTransactionService service, int accountId)
        {
            Log.Information("Called GetAccountTransactionHistory param: {accountId}", accountId);
            var accountTransactions = await service.GetAllTransanctions(accountId);
            if (!accountTransactions.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(accountTransactions);
        }
    }
}
