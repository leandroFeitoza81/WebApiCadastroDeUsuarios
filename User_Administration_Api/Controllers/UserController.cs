using Microsoft.AspNetCore.Mvc;
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

        //[HttpPost]
        //[Route("Add")]
        //public async Task<UsersModel> CreateNewUser(UsersModel user)
        //{

        //    return new UsersModel();
        //}

        [HttpGet]
        [Route("findAll")]
        public async Task<IActionResult> TestaConexao()
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

    }
}
