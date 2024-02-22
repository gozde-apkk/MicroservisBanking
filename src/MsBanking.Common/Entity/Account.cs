using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Entity
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string IbanNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public int AccountSuffix { get; set; }
    }
}
