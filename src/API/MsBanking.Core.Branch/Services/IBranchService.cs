using MsBanking.Common.Dto;

namespace MsBanking.Core.Branch.Services
{
    public interface IBranchService
    {
        Task<BranchResponseDto> CreateBranchAsync(BranchDto branchDto);
        Task<bool> DeleteBranchAsync(int id);
        Task<BranchResponseDto> GetBranchByIdAsync(int id);
        Task<List<BranchResponseDto>> GetBranchesAsync();
        Task<BranchResponseDto> UpdateBranchAsync(int id, BranchDto branchDto);
    }
}