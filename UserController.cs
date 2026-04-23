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
    }
}