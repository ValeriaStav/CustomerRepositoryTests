using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO [Customer] (FirstName, LastName, CustomerPhoneNumber, CustomerEmail, TotalPurchaseAmount) VALUES (@FirstName, @LastName, @CustomerPhoneNumber, @CustomerEmail, @TotalPurchaseAmount)", connection);

            var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
            {
                Value = entity.FirstName
            };
            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = entity.LastName
            };
            var customerPhoneNumberParam = new SqlParameter("@CustomerPhoneNumber", SqlDbType.NVarChar, 15)
            {
                Value = entity.CustomerPhoneNumber
            };
            var customerEmailParam = new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 50)
            {
                Value = entity.CustomerEmail
            };
            var totalPurchaseAmountParam = new SqlParameter("@TotalPurchaseAmount", SqlDbType.NVarChar, 50)
            {
                Value = entity.TotalPurchaseAmount
            };

            command.Parameters.Add(firstNameParam);
            command.Parameters.Add(lastNameParam);
            command.Parameters.Add(customerPhoneNumberParam);
            command.Parameters.Add(customerEmailParam);
            command.Parameters.Add(totalPurchaseAmountParam);

            command.ExecuteNonQuery();
        }

        public Customer Read(string entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("SELECT * FROM [Customer] WHERE LastName = @LastName", connection);
            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = entity
            };

            command.Parameters.Add(lastNameParam);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Customer
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    CustomerPhoneNumber = reader["CustomerPhoneNumber"].ToString(),
                    CustomerEmail = reader["CustomerEmail"].ToString(),
                    TotalPurchaseAmount = (decimal)reader["TotalPurchaseAmount"]
                };
            }
            return null;
        }

        public void Update(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("UPDATE [Customer] SET LastName = @LastName WHERE FirstName = @FirstName", connection);
            
            var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
            {
                Value = entity.FirstName
            };
            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = entity.LastName
            };
            var customerPhoneNumberParam = new SqlParameter("@CustomerPhoneNumber", SqlDbType.NVarChar, 15)
            {
                Value = entity.CustomerPhoneNumber
            };
            var customerEmailParam = new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 50)
            {
                Value = entity.CustomerEmail
            };
            var totalPurchaseAmountParam = new SqlParameter("@TotalPurchaseAmount", SqlDbType.NVarChar, 50)
            {
                Value = entity.TotalPurchaseAmount
            };

            command.Parameters.Add(firstNameParam);
            command.Parameters.Add(lastNameParam);
            command.Parameters.Add(customerPhoneNumberParam);
            command.Parameters.Add(customerEmailParam);
            command.Parameters.Add(totalPurchaseAmountParam);

            command.ExecuteNonQuery();
        }
        public void Delete(string entityLastName)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("DELETE FROM [Customer] WHERE LastName = @LastName", connection);

            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = entityLastName
            };

            command.Parameters.Add(lastNameParam);

            command.ExecuteNonQuery();
        }

        public void DeleteAll()
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("DELETE FROM [Customer]", connection);
            command.ExecuteNonQuery();
        }
    }
}