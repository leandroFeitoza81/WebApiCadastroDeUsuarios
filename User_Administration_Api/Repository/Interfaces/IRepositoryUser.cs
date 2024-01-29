using User_Administration_Api.Models;
using User_Administration_Api.Models.DTO;

namespace User_Administration_Api.Repository.Interfaces
{
    public interface IRepositoryUser
    {
        Task<IEnumerable<UserModelDto>> FindAll();
        Task<UserModelDto> FindById(int id);
        Task<UserModelDto> FindByName(string name);
        Task<UserModelDto> FindByEmail(string email);
        Task<bool> CreateNewUser(UserModel user);
        Task<bool> UpdateUser(UserModelDto user);
        Task<bool> DeleteUser(int id);

    }
}
