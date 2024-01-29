using System.Text.Json.Serialization;

namespace User_Administration_Api.Models.DTO
{
    public class UserModelDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string NickName { get; private set; }
        public DateTime DateBirth { get; private set; }

        [JsonConstructor]
        public UserModelDto(int id, string name, string email, string nickName, DateTime dateBirth)
        {
            Id = id;
            Name = name;
            Email = email;
            NickName = nickName;
            DateBirth = dateBirth;
        }

        public UserModelDto(string name, string email, string nickName, DateTime dateBirth)
        {
            Name = name;
            Email = email;
            NickName = nickName;
            DateBirth = dateBirth;
        }
    }

   
}
