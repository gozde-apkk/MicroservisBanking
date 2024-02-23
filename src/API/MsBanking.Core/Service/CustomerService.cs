using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MsBanking.Common.Dto;
using MsBanking.Common.Entity;
using MsBanking.Core.Domain;

namespace MsBanking.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> customerCollection;
        private readonly IMapper mapper;

        public CustomerService(IOptions<DatabaseOptions> options, IMapper _mapper)
        {
            var dbOptions = options.Value;
            var client = new MongoClient(dbOptions.ConnectionString);//bağlantı
            var database = client.GetDatabase(dbOptions.DatabaseName);//veritabanı
            customerCollection = database.GetCollection<Customer>(dbOptions.CustomerCollectionName);//tablo
            mapper = _mapper;
        }

        public async Task<CustomerResponseDto> GetCustomer(string id)
        {
            var customerEntity = await customerCollection.FindAsync(c => c.Id == id);
            var entity = customerEntity.FirstOrDefault();
            var mapped = mapper.Map<CustomerResponseDto>(entity);
            return mapped;
        }

        public async Task<List<CustomerResponseDto>> GetCustomers()
        {
            var customersEntities = await customerCollection.FindAsync(c => true);
            var customerList = customersEntities.ToList();
            var mapped = mapper.Map<List<CustomerResponseDto>>(customerList);
            return mapped;
        }

        public async Task<CustomerResponseDto> CreateCustomer(CustomerDto customer)
        {
             var customerEntity = mapper.Map<Customer>(customer);

            customerEntity.CreatedDate = DateTime.Now;
            customerEntity.UpdatedDate = DateTime.Now;
            customerEntity.isActive = true;

            await customerCollection.InsertOneAsync(customerEntity);

            var customerResponse = mapper.Map<CustomerResponseDto>(customerEntity);
            return customerResponse;
        }

        public async Task<CustomerResponseDto> UpdateCustomer(string id, CustomerDto customer)
        {

            var customerEntity = mapper.Map<Customer>(customer);
            customerEntity.UpdatedDate = DateTime.Now;
            await customerCollection.ReplaceOneAsync(c => c.Id == id, customerEntity);
            
            var customerResponseDto = mapper.Map<CustomerResponseDto>(customerEntity);
            return customerResponseDto; 
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            var customerEntity = await customerCollection.FindAsync(c => c.Id == id);
            var entity = customerEntity.FirstOrDefault();
            entity.isActive = false;
            var result = await customerCollection.ReplaceOneAsync(c => c.Id == id, entity);
            return result.ModifiedCount > 0;

        }   

    }
}
