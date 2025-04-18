using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Basma_App.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Hardcoded credentials
            if (username == "admin" && password == "1234")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login");
        }

    }
}
