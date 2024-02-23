using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Dto
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }
        public string IbanNumber { get; set; }
        public int AccountType { get; set; } //Bireysel & Tüzel
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public int AccountSuffix { get; set; }
    }

    public class AccountResponseDto : AccountDto
    {
        public int Id { get; set; }
    }

    public class AccountDtoProfile : AutoMapper.Profile
    {
        public AccountDtoProfile()
        {
            CreateMap<AccountDto, MsBanking.Common.Entity.Account>().ReverseMap();
            CreateMap<AccountResponseDto, MsBanking.Common.Entity.Account>().ReverseMap();
        }
    }
}
