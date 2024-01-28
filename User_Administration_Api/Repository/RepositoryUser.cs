using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using User_Administration_Api.Models;
using User_Administration_Api.Repository.Interfaces;

namespace User_Administration_Api.Repository
{
    public class RepositoryUser(IConfiguration configuration) : IRepositoryUser
    {
        private readonly string _connectionString = configuration.GetConnectionString("UsersDataBase")
            ?? throw new InvalidOperationException("ConnectionString 'UserDataBase' not found!");

        public Task<IActionResult> CreateNewUser(UsersModel user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsersModel>> FindAll()
        {
            var users = new List<UsersModel>();
            await using var connection = new SqlConnection(_connectionString);

            connection.Open();

            string sql = "SELECT * FROM Tb_User";

            var cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UsersModel(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5)
                        ));
            }
            return users;
        }

        public async Task<UsersModel> FindByEmail(string email)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Email = @email";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", email);

            connection.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            UsersModel user = new();
            while (reader.Read())
            {
                user = new UsersModel(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public async Task<UsersModel> FindById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Id = @id";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            UsersModel user = new();
            while (reader.Read())
            {
                user = new UsersModel(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public async Task<UsersModel> FindByName(string name)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Name like '%'+@name+'%'";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", name);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            UsersModel user = new();
            while (reader.Read())
            {
                user = new UsersModel(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public Task<IActionResult> UpdateUser(UsersModel user)
        {
            throw new NotImplementedException();
        }
    }
}
