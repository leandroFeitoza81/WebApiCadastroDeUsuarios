using Microsoft.AspNetCore.Mvc;
using User_Administration_Api.Models;
using User_Administration_Api.Models.DTO;
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
        public async Task<IActionResult> PostNewUser([FromBody] UserModel user)
        {
            try
            {
                var userCreated = await _repository.CreateNewUser(user);

                if (!userCreated)
                    return BadRequest();

                return Created();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UserModelDto user)
        {
            try
            {
                var searchUser = await _repository.FindById(user.Id);
                if (searchUser == null)
                    return BadRequest("Usuário não encontrado na base.");

                var userUpdated = await _repository.UpdateUser(user);

                if (!userUpdated)
                    return BadRequest();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var userDeleted = await _repository.DeleteUser(id);

                if (!userDeleted)
                    return BadRequest();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
