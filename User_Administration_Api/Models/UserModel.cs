using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace User_Administration_Api.Models
{
    public class UserModel(string name, string email, string nickName, string password, DateTime dateBirth)
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Campo não pode ter mais que 50 caracteres.")]
        public string Name { get; private set; } = name;

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Campo não pode ter mais que 100 caracteres.")]
        public string Email { get; private set; } = email;

        [StringLength(50, ErrorMessage = "Campo não pode ter mais que 50 caracteres.")]
        public string Nickname { get; private set; } = nickName;

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(500, ErrorMessage = "Campo não pode ter mais que 500 caracteres.")]
        //[JsonIgnore]
        public string Password { get; private set; } = password;

        public DateTime DateBirth { get; private set; } = dateBirth;
    }
}
