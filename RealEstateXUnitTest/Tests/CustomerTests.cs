using AutoMapper;
using AutoMapper.EquivalencyExpression;
using RealEstateApi.Dto.Request;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateXUnitTest.Tests
{
    public class CustomerTests
    {
        private readonly IMapper _mapper;
        private readonly RSFixture _fixture;

        public CustomerTests()
        {
            _fixture = new RSFixture();
            _fixture.Initialize();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddCollectionMappers();
            }));
        }

        [Fact]
        public async Task ShouldAddCustomer()
        {
            var customerService = GetInstance();

            var customerData = new CustomerRequestDto
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "1234567890"
            };

            var result = await customerService.AddCustomerAsync(customerData);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("John Doe", result.Result.Name);

            var savedCustomer = await _fixture.DbContext.Customers.FindAsync(result.Result.Id);
            Assert.NotNull(savedCustomer);
            Assert.Equal("John Doe", savedCustomer.Name);
        }

        [Fact]
        public async Task ShouldGetAllCustomer()
        {
            var customerService = GetInstance();

            _fixture.DbContext.Customers.Add(new Customer { Name = "Lebron James", Email = "james@lebron.com", Password = "987654321" });
            _fixture.DbContext.Customers.Add(new Customer { Name = "James Lebron", Email = "lebron@james.com", Password = "987654321" });
            await _fixture.DbContext.SaveChangesAsync();

            var result = await customerService.GetAllCustomersAsync();

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Result.Count);
            Assert.Contains(result.Result, customer => customer.Name == "Lebron James");
            Assert.Contains(result.Result, customer => customer.Name == "James Lebron");
        }

        [Fact]
        public async Task ShouldGetCustomerById()
        {
            var customerService = GetInstance();

            var customer = new Customer { Name = "testeId", Email = "testeId@example.com", Password = "1234567890" };
            _fixture.DbContext.Customers.Add(customer);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await customerService.GetCustomerByIdAsync(customer.Id);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("testeId", result.Result.Name);
        }

        [Fact]
        public async Task ShouldDeleteCustomer()
        {
            var customerService = GetInstance();

            var customer = new Customer { Name = "deleted", Email = "deleted@example.com", Password = "1234567890" };
            _fixture.DbContext.Customers.Add(customer);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await customerService.DeleteCustomerByIdAsync(customer.Id);

            Assert.True(result.IsSuccess);

            var deletedCustomer = await _fixture.DbContext.Customers.FindAsync(customer.Id);
            Assert.Null(deletedCustomer);
        }

        private ICustomerService GetInstance()
        {
            return new CustomerService(_fixture.DbContext, _mapper);
        }
    }
}