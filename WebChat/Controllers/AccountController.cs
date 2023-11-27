using CorLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace WebChat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                return RedirectToAction(nameof(Index));
            }

            var res=await _userService.UserRegister(model);   
            if (!res )
            {
                ModelState.AddModelError(model.UserName, "نام کاربری تکراری است .");
                return View("Index", model);
            }
            return Redirect("/account");
        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var user = await _userService.UserLogin(model);
            if (user == null)
            {
                ModelState.AddModelError(model.UserName,"کاربری یافت نشد");
                return RedirectToAction(nameof(Index));
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal=new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(principal);
            return Redirect("/");
        }

    }
}
