using MsBanking.Common.Entity;

namespace MsBanking.Core.Service
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<List<Customer>> GetCustomers();
    }
}