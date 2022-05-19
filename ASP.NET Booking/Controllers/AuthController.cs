using ASP.NET_Booking.Data;
using ASP.NET_Booking.Models;
using ASP.NET_Booking.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ASP.NET_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _userContext;

        public HomeController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _userContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            return await Exit();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userContext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    await Auth(user.UserName);
                    RedirectToAction("Privacy", "Home");
                }
                else
                {
                    ModelState.AddModelError("auth", "Username or Password is wrong!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromForm] RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userContext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

                if (user != null)
                {
                    ModelState.AddModelError("auth", "User is already registered!");
                    //return Content($@"{model.UserName} has been registered!");
                }
                else
                {
                    await _userContext.Users.AddAsync(new User() { Password = model.Password, UserName = model.UserName });
                    _userContext.SaveChanges();
                    User user2 = await _userContext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                    await Auth(user2.UserName);
                    return RedirectToAction("Privacy");
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Test()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task Auth(string userName)
        {
            List<Claim> claims = new List<Claim>();
            Claim claim = new Claim(ClaimsIdentity.DefaultNameClaimType, userName);
            Claim role = new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin");
            claims.Add(claim);
            claims.Add(role);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
