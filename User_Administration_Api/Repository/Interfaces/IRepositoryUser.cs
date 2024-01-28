using Microsoft.AspNetCore.Mvc;
using User_Administration_Api.Models;

namespace User_Administration_Api.Repository.Interfaces
{
    public interface IRepositoryUser
    {
        Task<IEnumerable<UsersModel>> FindAll();
        Task<UsersModel> FindById(int id);
        Task<UsersModel> FindByName(string name);
        Task<UsersModel> FindByEmail(string email);
        Task<UsersModel?> CreateNewUser(UsersModel user);
        bool UpdateUser(UsersModel user);
        bool DeleteUser(int id);

    }
}
