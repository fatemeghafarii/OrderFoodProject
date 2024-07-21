using Microsoft.EntityFrameworkCore;
using OrderFood.Application.Contract.Customers;
using OrderFood.Domain.Customers;
using OrderFood.Domain.Customers.Arguments;
using OrderFood.Framework.Persistence.EF;

namespace OrderFood.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> CreateAsync(CustomerCreateDto customerCreateDto)
        {
            var customer = new Customer(Guid.NewGuid(), customerCreateDto.MapToArgument());
            return await _customerRepository.CreateAsync(customer);
        }

        public async Task<List<CustomerGetDto>> GetAsync(int skip, int take)
        {
            var customers = await _customerRepository.GetAsNoTracking().Skip(skip).Take(take).ToListAsync();
            var result = customers.Select(c => new CustomerGetDto
            {
                Name = c.Name,
            }).ToList();

            return result;
        }

        public async Task<CustomerGetDto?> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();
            return new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();
            var customerArg = new CustomerArg
            (
               Name: customer.Name
            );
            customer = new Customer(id, customerArg);
            return await _customerRepository.RemoveAsync(customer);
        }

        public async Task<int> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerRepository.GetAsNoTracking().FirstAsync(o => o.Id == customerUpdateDto.Id);
            customer = new Customer(customerUpdateDto.Id, customerUpdateDto.MapToArgument(customer));
            return await _customerRepository.UpdateAsync(customer);
        }
    }
}
