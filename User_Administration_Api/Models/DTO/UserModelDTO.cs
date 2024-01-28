namespace User_Administration_Api.Models.DTO
{
    public class UserModelDTO(string name, string email, string nickName, DateTime dateBirth)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string NickName { get; private set; } = nickName;
        public DateTime DateBirth { get; private set; } = dateBirth;
    }
}
