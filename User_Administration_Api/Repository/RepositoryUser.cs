using System.Data.SqlClient;
using User_Administration_Api.Models;
using User_Administration_Api.Models.DTO;
using User_Administration_Api.Repository.Interfaces;

namespace User_Administration_Api.Repository
{
    public class RepositoryUser(IConfiguration configuration) : IRepositoryUser
    {

        private readonly string _connectionString = configuration.GetConnectionString("UsersDataBase")
            ?? throw new InvalidOperationException("ConnectionString 'UserDataBase' not found!");

        public async Task<bool> CreateNewUser(UserModel user)
        {
            await using var connection = new SqlConnection(_connectionString);

            string sql = "INSERT INTO Tb_User (" +
                "Name, Email, NickName, Password, DateBirth ) " +
                "VALUES (" +
                "@name, @email, @nickName, @password, @dateBirth)";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@nickName", user.Nickname);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@dateBirth", user.DateBirth);

            connection.Open();
            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "DELETE FROM Tb_User WHERE Id = @id";

            var cmd = new SqlCommand(sql, connection);

            connection.Open();
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;

        }

        public async Task<IEnumerable<UserModelDto>> FindAll()
        {
            var users = new List<UserModelDto>();
            await using var connection = new SqlConnection(_connectionString);

            string sql = "SELECT * FROM Tb_User";

            var cmd = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UserModelDto(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(5)
                        ));
            }
            return users;
        }

        public async Task<UserModelDto> FindByEmail(string email)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Email = @email";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", email);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserModelDto user = null;
            while (reader.Read())
            {
                user = new UserModelDto(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public async Task<UserModelDto> FindById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Id = @id";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserModelDto user = null;
            while (reader.Read())
            {
                user = new UserModelDto(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public async Task<UserModelDto> FindByName(string name)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Tb_User WHERE Name like '%'+@name+'%'";

            var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@name", name);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            UserModelDto user = null;
            while (reader.Read())
            {
                user = new UserModelDto(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(5));
            }

            return user;
        }

        public async Task<bool> UpdateUser(UserModelDto user)
        {
            await using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE Tb_User" +
                        " SET Name = @name," +
                            " Email = @email," +
                            " NickName = @nickName," +
                            " DateBirth = @dateBirth" +
                        " WHERE Id = @id;";
            var cmd = new SqlCommand(@sql, connection);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@nickName", user.NickName);
            cmd.Parameters.AddWithValue("@dateBirth", user.DateBirth);

            connection.Open();
            var rowAffected = cmd.ExecuteNonQuery();

            return rowAffected > 0;
        }
    }
}
