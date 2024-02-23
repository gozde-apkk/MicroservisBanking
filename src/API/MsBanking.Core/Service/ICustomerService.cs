using MsBanking.Common.Dto;
using MsBanking.Common.Entity;

namespace MsBanking.Core.Service
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateCustomer(CustomerDto customer);
        Task<CustomerResponseDto> GetCustomer(string id);
        Task<List<CustomerResponseDto>> GetCustomers();
        Task<CustomerResponseDto> UpdateCustomer(string id, CustomerDto customer);
        Task<bool> DeleteCustomer(string id);
    }
}