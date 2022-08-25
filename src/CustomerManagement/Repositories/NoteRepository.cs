using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Integration.Tests
{
    public class NoteRepository : BaseRepository, IRepository<Notes>
    {
        public void Create(Notes entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("INSERT INTO [Note] (CustomerId, Note) VALUES (@CustomerId,@Note)", connection);

            var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
            var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity.Note };

            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(noteParam);

            command.ExecuteNonQuery();
        }

        public Notes Read(string entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("SELECT * FROM [Note] WHERE NoteId = @NoteId", connection);

            var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int) { Value = entity };

            command.Parameters.Add(noteIdParam);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Notes
                {
                    NoteId = Convert.ToInt32(reader["NoteId"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    Note = reader["Note"].ToString()
                };
            }
            return null;
        }

        public void Update(Notes entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("UPDATE [Note] SET CustomerId = @CustomerId, Note = @Note WHERE NoteId = @NoteId", connection);

            var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int) { Value = entity.NoteId };
            var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
            var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity.Note };

            command.Parameters.Add(noteIdParam);
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(noteParam);

            command.ExecuteNonQuery();
        }

        public void Delete(string entity)
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("DELETE [Note] WHERE Note = @Note", connection);

            var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity };

            command.Parameters.Add(noteParam);

            command.ExecuteNonQuery();
        }
    }
}