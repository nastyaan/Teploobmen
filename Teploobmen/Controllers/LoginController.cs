using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Teploobmen.Data;

namespace Teploobmen.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyApplicationContext _context;

        public LoginController(ILogger<HomeController> logger, MyApplicationContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string login, string password)
        {
            var existUser = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            
            if(existUser == null)
            {
                ModelState.AddModelError("invalidLoginOrPassword", "Неверный логин или пароль");
                
                return View();
            }

            await AuthenticateAsync(existUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string login, string password)
        {
            var exitUser = _context.Users.Any( u => u.Login == login );
            
            if (exitUser)
            {
                ModelState.AddModelError("invalidLogin", "Такой пользователь уже существует");
               
                return View();
            }

            var user = new User { Login = login, Password = password };

            _context.Users.Add(user);
            _context.SaveChanges();

            await AuthenticateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private async Task AuthenticateAsync(User user)
        {
            var claims = new List<Claim> { 
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
