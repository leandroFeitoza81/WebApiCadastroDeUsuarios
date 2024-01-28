using Microsoft.AspNetCore.Mvc;
using User_Administration_Api.Models;
using User_Administration_Api.Repository.Interfaces;

namespace User_Administration_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IRepositoryUser _repository;

        public UserController(IRepositoryUser repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("findAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var retorno = await _repository.FindAll();

                if (retorno == null)
                    return NotFound(new { data = "Dados não encontrados." });

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("findByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var retorno = await _repository.FindByEmail(email);

                if (retorno == null)
                    return NotFound($"Usuário não encontrado na base com o email: {email}");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("findById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var retorno = await _repository.FindById(id);

                if (retorno == null)
                    return NotFound($"Usuário não encontrado na base com o id: {id}");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("findByName")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                var retorno = await _repository.FindByName(name);

                if (retorno == null)
                    return NotFound($"Usuário não encontrado na base com o id: {name}");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostNewUser(UsersModel user)
        {

            try
            {
                var retorno = await _repository.CreateNewUser(user);

                if (retorno == null)
                    return BadRequest();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
