using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MsBanking.Common.Dto;
using MsBanking.Common.Entity;
using MsBanking.Core.Domain;

namespace MsBanking.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> customerCollection;
        private readonly IMapper mapper;

        public CustomerService(IOptions<DatabaseOption> options, IMapper _mapper)
        {
            mapper = _mapper;
            var dbOptions = options.Value;
            var client = new MongoClient(dbOptions.ConnectionString);
            var database = client.GetDatabase(dbOptions.DatabaseName);
            customerCollection = database.GetCollection<Customer>(dbOptions.CustomerCollectionName);
        }


        public async Task<CustomerResponseDto> GetCustomer(int id)
        {
            var customerEntity = await customerCollection.FindAsync(c => c.Id == id);
            var entity = customerEntity.FirstOrDefault();
            var mapped = mapper.Map<CustomerResponseDto>(entity);
            return mapped;  
        }

        public async Task<List<CustomerResponseDto>> GetCustomers()
        {
            var customerEntities = await customerCollection.FindAsync(c => true);
            var customerList = customerEntities.ToList();
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

            var customerResponse = mapper.Map<CustomerResponseDto>(customer);
            return customerResponse;
        }

        public async Task<CustomerResponseDto> UpdateCustomer(int id, CustomerDto customer)
        {
            var customerEntity = mapper.Map<Customer>(customer);

            customerEntity.UpdatedDate = DateTime.Now;
            await customerCollection.ReplaceOneAsync(c => c.Id == id, customerEntity);

            var customerResponseDto = mapper.Map<CustomerResponseDto>(customerEntity);
            return customerResponseDto;
        }


        public async Task<bool> DeleteCustomer(int id)
        {
            var customerEntity = await customerCollection.FindAsync(x => x.Id == id);
            var entity = customerEntity.FirstOrDefault();
            entity.isActive = false;
            var result = await customerCollection.ReplaceOneAsync(x => x.Id == id, entity);
            return result.ModifiedCount > 0;    
        }

    }
}
