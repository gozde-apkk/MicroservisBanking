using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MsBanking.Common.Entity;
using MsBanking.Core.Domain;

namespace MsBanking.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> customerCollection;

        public CustomerService(IOptions<DatabaseOptions> options)
        {
            var dbOptions = options.Value;
            var client = new MongoClient(dbOptions.ConnectionString);//bağlantı
            var database = client.GetDatabase(dbOptions.DatabaseName);//veritabanı
            customerCollection = database.GetCollection<Customer>(dbOptions.CustomerCollectionName);//tablo
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await customerCollection.FindAsync(c => c.Id == id);
            return customer.FirstOrDefault();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await customerCollection.FindAsync(c => true);
            return customers.ToList();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await customerCollection.InsertOneAsync(customer);
            return customer;
        }
    }
}
