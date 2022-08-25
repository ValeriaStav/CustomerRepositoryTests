using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;
using FluentAssertions;

namespace CustomerManagement.Integration.Tests
{
    public class CustomerRepositoryTests
    {
        public CustomerRepositoryFixture Fixture => new CustomerRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Fixture.DeleteAll();
            var repositiry = new CustomerRepository();
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                CustomerPhoneNumber = "1234567890",
                CustomerEmail = "JohnD555@gmail.com",
                TotalPurchaseAmount = 10000
            };

            customer.Should().NotBe(null);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            Fixture.DeleteAll();
            Fixture.CreateMockCustomer();
            var createdCustomer = Fixture.CreateCustomerRepository().Read("Doe");

            createdCustomer.Should().NotBe(null);
            createdCustomer.LastName.Should().Be("Doe");
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            Fixture.DeleteAll();
            var customer = Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            customer.LastName = "Black";

            repository.Update(customer);
            customer.LastName.Should().Be("Black");
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            Fixture.DeleteAll();
            Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();

            repository.Delete("Doe");
            var deletedCustomer = repository.Read("Doe");
            deletedCustomer.Should().Be(null);

        }
    }

    public class CustomerRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }

        public Customer CreateMockCustomer()
        {
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                CustomerPhoneNumber = "1234567890",
                CustomerEmail = "JohnD555@gmail.com",
                TotalPurchaseAmount = 10000
            };

            var customerRepository = new CustomerRepository();
            customerRepository.Create(customer);
            return customer;
        }
        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}