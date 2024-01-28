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

            string sql = "SELECT * FROM Tb_Users";

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

        public Task<UsersModel> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UsersModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersModel> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateUser(UsersModel user)
        {
            throw new NotImplementedException();
        }
    }
}
