using AutoMapper;
using MsBanking.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsBanking.Common.Dto
{
    public class CustomerDto
    {
        public string? FullName { get; set; }

        public long? CitizenNumber { get; set; }
        public string? Email { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.MinValue;
    }

    public class CustomerDtoProfile : Profile
    {

        public CustomerDtoProfile ()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerResponseDto, Customer>().ReverseMap();
        }
    }

    public class CustomerResponseDto : CustomerDto
    {
        public string Id { get; set; } 
    }
}
