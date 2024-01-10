using Microsoft.AspNetCore.Mvc;
using ProfileService.Data.DTOs;
using ProfileService.Entities;
using ProfileService.Services.Interface;

namespace ProfileService.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] userDTO user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                return BadRequest("Error creating user");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] AppUser user)
        {
            try
            {

                await _userService.UpdateUserAsync(user);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return BadRequest("Error updating user");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound($"User with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return BadRequest("Error retrieving user");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            {
                try
                {
                    await _userService.DeleteUserAsync(id);
                    return Ok("User deleted successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting user: {ex.Message}");
                    return BadRequest("Error deleting user");
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
                return BadRequest("Error retrieving users");
            }
        }

    }
}
