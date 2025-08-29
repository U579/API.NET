using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing user-related operations.
/// </summary>
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]

    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    /// <param name="createUser"></param>
    /// <param name="updateUser"></param>
    /// <param name="patchUser"></param>
    /// <param name="deleteUser"></param>
    /// <param name="getUser"></param>
    public class UserController(
        CreateUserService createUser,
        UpdateUserService updateUser,
        PatchUserService patchUser,
        DeleteUserService deleteUser,
        GetUserService getUser) : ControllerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="createUser"></param>
        /// <param name="updateUser"></param>
        /// <param name="patchUser"></param>
        /// <param name="deleteUser"></param>
        /// <param name="getUser"></param>
        private readonly CreateUserService _createUser = createUser;
        private readonly UpdateUserService _updateUser = updateUser;
        private readonly PatchUserService _patchUser = patchUser;
        private readonly DeleteUserService _deleteUser = deleteUser;
        private readonly GetUserService _getUser = getUser;

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _getUser.GetAllAsync());

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _getUser.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _createUser.ExecuteAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            await _updateUser.ExecuteAsync(user);
            return NoContent();
        }

        /// <summary>
        /// Partially updates a user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updates"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] Dictionary<string, object> updates)
        {
            var success = await _patchUser.ExecuteAsync(id, updates);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUser.ExecuteAsync(id);
            return NoContent();
        }
    }
}
