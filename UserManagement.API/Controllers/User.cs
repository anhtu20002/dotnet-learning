using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain.Entities;
using UserManagement.Application.UseCases;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;

        public UsersController(CreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _createUserUseCase.ExecuteAsync(user);
            return Ok();
        }
    }
}