using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SkillFoundryAuthBasics.Models;
using System.Security.Claims;

namespace SkillFoundryAuthBasics.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            var account = UserManager.Login(model.UserName, model.Password);

            if (account != null)
            {
                var identity = new ClaimsIdentity(account.Claims, Settings.AuthCookieName);
                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                };

                await HttpContext.SignInAsync(Settings.AuthCookieName, principal, props);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Settings.AuthCookieName);
            return RedirectToAction("Index", "Home");
        }
    }
}
