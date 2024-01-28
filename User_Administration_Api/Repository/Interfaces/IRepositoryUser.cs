using User_Administration_Api.Models;
using User_Administration_Api.Models.DTO;

namespace User_Administration_Api.Repository.Interfaces
{
    public interface IRepositoryUser
    {
        Task<IEnumerable<UserModelDTO>> FindAll();
        Task<UserModelDTO> FindById(int id);
        Task<UserModelDTO> FindByName(string name);
        Task<UserModelDTO> FindByEmail(string email);
        Task<bool> CreateNewUser(UsersModel user);
        Task<bool> UpdateUser(UsersModel user);
        Task<bool> DeleteUser(int id);

    }
}
