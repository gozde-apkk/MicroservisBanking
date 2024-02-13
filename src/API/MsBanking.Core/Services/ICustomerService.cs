using MsBanking.Common.Entity;

namespace MsBanking.Core.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<List<Customer>> GetCustomers();
    }
}