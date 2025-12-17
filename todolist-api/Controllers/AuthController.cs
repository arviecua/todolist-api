using Microsoft.AspNetCore.Mvc;
using todolist_api.Services;

namespace todolist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly AuthService authService;
        public AuthController() => authService = new();

        [HttpGet]
        public IActionResult Get() => Ok(authService.Init());
    }
}
