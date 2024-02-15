using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Entity
{

    public class Branch
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
    }
}
