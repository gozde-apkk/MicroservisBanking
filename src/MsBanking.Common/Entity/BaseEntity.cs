using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Entity
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }  
    }
}
