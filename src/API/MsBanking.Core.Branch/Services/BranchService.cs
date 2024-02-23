using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MsBanking.Common.Dto;

namespace MsBanking.Core.Branch.Services
{
    public class BranchService : IBranchService
    {

        private readonly BranchDbContext context;
        private readonly IMapper mapper;


        public BranchService(BranchDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BranchResponseDto>> GetBranchesAsync()
        {
            var branches = await context.Branches.ToListAsync();
            var mapped = mapper.Map<List<BranchResponseDto>>(branches);

            return mapped;
        }

        public async Task<BranchResponseDto> GetBranchAsync(int id)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(x => x.Id == id);
            var mapped = mapper.Map<BranchResponseDto>(branch);

            return mapped;
        }

        public async Task<BranchResponseDto> CreateBranchAsync(BranchDto branchDto)
        {
            var branch = mapper.Map<MsBanking.Common.Entity.Branch>(branchDto);
            await context.Branches.AddAsync(branch);
            await context.SaveChangesAsync();

            return mapper.Map<BranchResponseDto>(branch);
        }

        public async Task<BranchResponseDto> UpdateBranchAsync(int id, BranchDto branchDto)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(x => x.Id == id);
            mapper.Map(branchDto, branch);
            await context.SaveChangesAsync();

            return mapper.Map<BranchResponseDto>(branch);
        }


        public async Task DeleteBranchAsync(int id)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(x => x.Id == id);
            context.Branches.Remove(branch);
            await context.SaveChangesAsync();
        }
    }
}
