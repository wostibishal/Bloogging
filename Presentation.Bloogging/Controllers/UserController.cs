using Application.Blooging;
using Domain.Bloogging.User;
using Infrastructure.Blogging;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Bloogging.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent(User user)
        {
            var addedUser = await _UserService.AddUser(user);
            return Ok(addedUser);
        }

        [HttpDelete] // Use HttpDelete for deleting resources
        [Route("DeleteUser/{id}")] // Use route parameter for ID
        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _UserService.DeleteUser(id);
            return NoContent(); // NoContent is a common response for delete operations
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var user = await _UserService.GetUserById(id);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetUser/{role}")]
        public async Task<IActionResult> GetUserByRole(string role)
        {
            try
            {
                var users = await _UserService.GetUserByRole(role);
                if (users == null)
                {
                    return NotFound($"No user found with role {role}.");
                }

                return Ok(users);
            }
            catch (Exception ex) // You might want to catch more specific exceptions depending on your scenario
            {
                // Log the exception details here
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _UserService.GetAllUser();
            return Ok(users);
        }

        [HttpPut] // Use HttpPut for updating resources
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                var updatedUser = await _UserService.UpdateUser(user);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
