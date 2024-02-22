using MsBanking.Common.Dto;
using MsBanking.Common.Entity;

namespace MsBanking.Core.Service
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateCustomer(CustomerDto customer);
        Task<CustomerResponseDto> GetCustomer(int id);
        Task<List<CustomerResponseDto>> GetCustomers();
        Task<CustomerResponseDto> UpdateCustomer(int id, CustomerDto customer);
        Task<bool> DeleteCustomer(int id);
    }
}