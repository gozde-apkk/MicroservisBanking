using Microsoft.AspNetCore.Http.HttpResults;
using MsBanking.Common.Dto;
using MsBanking.Core.Branch.Services;

namespace MsBanking.Core.Branch.Apis
{
    public static class BranchApi
    {

        public static IEndpointRouteBuilder MapBranchApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/branch", GetAllBranches);
            app.MapGet("/branch/{id}", GetBranch);
            app.MapPost("/branch", CreateBranch);
            app.MapPut("/branch/{id}", UpdateBranch);
            app.MapDelete("/branch/{id}", DeleteBranch);
            return app;
        }


        private static async Task<Results<Ok<List<BranchResponseDto>>, NotFound>> GetAllBranches(IBranchService service)
        {
            var branches = await service.GetBranchesAsync();
            if (!branches.Any())
                return TypedResults.NotFound();
            return TypedResults.Ok(branches);
        }
        private static async Task<Results<Ok<BranchResponseDto>, NotFound>> GetBranch(IBranchService service, int id)
        {
            var branch = await service.GetBranchByIdAsync(id);
            if (branch == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(branch);
        }

        private static async Task<Results<Ok<BranchResponseDto>, BadRequest>> CreateBranch(IBranchService service, BranchDto branch)
        {
            var createdBranch = await service.CreateBranchAsync(branch);
            return TypedResults.Ok(createdBranch);
        }
        private static async Task<Results<Ok<BranchResponseDto>, NotFound>> UpdateBranch(IBranchService service, int id, BranchDto branch)
        {
            var updatedBranch = await service.UpdateBranchAsync(id, branch);
            if (updatedBranch == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(updatedBranch);
        }

        private static async Task<Results<Ok, NotFound>> DeleteBranch(IBranchService service, int id)
        {
            var deleted = await service.DeleteBranchAsync(id);
            if (!deleted)
                return TypedResults.NotFound();
            return TypedResults.Ok();
        }
    }
}

