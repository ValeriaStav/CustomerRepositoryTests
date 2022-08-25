using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public void Create(Address entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO [Address] (CustomerId, AddressLine, AddressLine2, AddressType, City, PostalCode, State, Country)" +
                "VALUES (@CustomerId, @AddressLine, @AddressLine2, @AddressType, @City, @PostalCode, @State, @Country)", connection);

            var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
            {
                Value = entity.CustomerId
            };
            var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
            {
                Value = entity.AddressLine
            };
            var addressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
            {
                Value = entity.AddressLine2
            };
            var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 8)
            {
                Value = entity.AddressType
            };
            var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
            {
                Value = entity.City
            };
            var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
            {
                Value = entity.PostalCode
            };
            var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20)
            {
                Value = entity.State
            };
            var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 30)
            {
                Value = entity.Country
            };

            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(addressLineParam);
            command.Parameters.Add(addressLine2Param);
            command.Parameters.Add(addressTypeParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(postalCodeParam);
            command.Parameters.Add(stateParam);
            command.Parameters.Add(countryParam);

            command.ExecuteNonQuery();
        }

        public Address Read(string entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("SELECT * FROM [Address] WHERE AddressId = @AddressId", connection);

            var customerIdParam = new SqlParameter("@AddressId", SqlDbType.Int) { Value = entity };

            command.Parameters.Add(customerIdParam);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Address
                {
                    AddressId = Convert.ToInt32(reader["AddressId"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    AddressLine = reader["AddressLine"].ToString(),
                    AddressLine2 = reader["AddressLine2"].ToString(),
                    AddressType = reader["AddressType"].ToString(),
                    City = reader["City"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    State = reader["State"].ToString(),
                    Country = reader["Country"].ToString()
                };
            }
            return null;
        }

        public void Update(Address entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("UPDATE [Address] SET CustomerId = @CustomerId, AddressLine = @AddressLine, AddressLine2 = @AddressLine2, AddressType = @AddressType, City= @City, PostalCode = @PostalCode, State = @State, Country = @Country WHERE AddressId = @AddressId", connection);

            var addressIdParam = new SqlParameter("@AddressId", SqlDbType.Int) { Value = entity.AddressId };
            var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
            var addresLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100) { Value = entity.AddressLine };
            var addresLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100) { Value = entity.AddressLine2 };
            var addresTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 20) { Value = entity.AddressType };
            var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = entity.City };
            var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6) { Value = entity.PostalCode };
            var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20) { Value = entity.State };
            var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 100) { Value = entity.Country };

            command.Parameters.Add(addressIdParam);
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(addresLineParam);
            command.Parameters.Add(addresLine2Param);
            command.Parameters.Add(addresTypeParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(postalCodeParam);
            command.Parameters.Add(stateParam);
            command.Parameters.Add(countryParam);

            command.ExecuteNonQuery();
        }

        public void Delete(string entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("DELETE [Address] WHERE AddressLine2 = @AddressLine2", connection);

            var addressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100) { Value = entity };

            command.Parameters.Add(addressLine2Param);

            command.ExecuteNonQuery();
        }
    }
}