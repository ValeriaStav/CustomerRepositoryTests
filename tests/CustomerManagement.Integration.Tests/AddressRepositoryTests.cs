using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;

namespace CustomerManagement.Integration.Tests
{
    public class AddressRepositoryTests
    {
        public AddressRepositoryFixture Fixture => new AddressRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Fixture.DeleteAll();
            var repository = new AddressRepository();
            var address = new Address()
            {
                CustomerId = 1,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Shipping",
                City = "Ottawa",
                PostalCode = "123456",
                State = "Ontario",
                Country = "Canada"

            };
            repository.Create(address);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            Fixture.DeleteAll();
            var addressCustomer = Fixture.CreateAddresRepository().Read("10");
            Assert.Equal(10, addressCustomer.AddressId);
            Assert.Equal("First line", addressCustomer.AddressLine);
        }

        [Fact]
        public void ShouldBeAbleToReadNullAddress()
        {
            Fixture.DeleteAll();
            var addressCustomer = Fixture.CreateAddresRepository().Read("0");
            Assert.Null(addressCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUodateAddress()
        {
            Fixture.DeleteAll();
            var address = new Address()
            {
                AddressId = 80,
                CustomerId = 2,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Billing",
                City = "Chicago",
                PostalCode = "654321",
                State = "Illinois",
                Country = "USA"

            };
            Fixture.CreateAddresRepository().Update(address);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var address = new Address()
            {
                CustomerId = 1,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Shipping",
                City = "Ottawa",
                PostalCode = "123456",
                State = "Ontario",
                Country = "Canada"
            };
            Fixture.CreateAddresRepository().Create(address);
            Fixture.CreateAddresRepository().Delete(address.AddressLine2);
        }

    }

    public class AddressRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }

        public AddressRepository CreateAddresRepository()
        {
            return new AddressRepository();
        }
    }
}
