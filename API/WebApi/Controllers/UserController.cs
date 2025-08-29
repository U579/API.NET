using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(
        CreateUserService createUser,
        UpdateUserService updateUser,
        PatchUserService patchUser,
        DeleteUserService deleteUser,
        GetUserService getUser) : ControllerBase
    {
        private readonly CreateUserService _createUser = createUser;
        private readonly UpdateUserService _updateUser = updateUser;
        private readonly PatchUserService _patchUser = patchUser;
        private readonly DeleteUserService _deleteUser = deleteUser;
        private readonly GetUserService _getUser = getUser;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _getUser.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _getUser.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _createUser.ExecuteAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            await _updateUser.ExecuteAsync(user);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] Dictionary<string, object> updates)
        {
            var success = await _patchUser.ExecuteAsync(id, updates);
            return success ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUser.ExecuteAsync(id);
            return NoContent();
        }
    }
}
