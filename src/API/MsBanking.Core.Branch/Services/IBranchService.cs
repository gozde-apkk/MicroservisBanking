using MsBanking.Common.Dto;

namespace MsBanking.Core.Branch.Services
{
    public interface IBranchService
    {
        Task<BranchResponseDto> CreateBranchAsync(BranchDto branchDto);
        Task DeleteBranchAsync(int id);
        Task<BranchResponseDto> GetBranchAsync(int id);
        Task<List<BranchResponseDto>> GetBranchesAsync();
        Task<BranchResponseDto> UpdateBranchAsync(int id, BranchDto branchDto);
    }
}