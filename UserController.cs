namespace WebAPITask1
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "Иван" },
            new User { Id = 2, Name = "Пётр" },
            new User { Id = 3, Name = "Анна" },
            new User { Id = 4, Name = "Мария" },
            new User { Id = 5, Name = "Секретный пользователь" },
        };

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = FindUserById(id);

            if (user == null)
            {
                return NotFound($"Пользователь с id = {id} не найден");
            }

            if (id == 5)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Доступ к пользователю с id = 5 запрещён");
            }

            return Ok(user);
        }

        [HttpPut("id")]
        public ActionResult<User> UpdateUserName(int id, [FromBody] string newName)
        {
            var user = FindUserById(id);

            if (user == null)
            {
                return NotFound($"Пользователь с id = {id} не найден");
            }

            user.Name = newName;

            return Ok(user);
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            var user = FindUserById(id);

            if (user == null)
            {
                return NotFound($"Пользователь с id = {id} не найден");
            }

            _users.Remove(user);

            return Ok($"Пользователь с id = {id} удалён");
        }

        private User? FindUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}