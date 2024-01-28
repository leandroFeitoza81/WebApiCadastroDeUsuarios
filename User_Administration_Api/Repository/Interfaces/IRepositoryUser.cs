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
        Task<IActionResult> CreateNewUser(UsersModel user);
        Task<IActionResult> UpdateUser(UsersModel user);
        Task<IActionResult> DeleteUser(int id);

    }
}
