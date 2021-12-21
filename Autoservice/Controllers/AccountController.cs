using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Autoservice.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using Autoservice.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Autoservice.Data;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Autoservice.Controllers
{
    public class AccountController : Controller
    {
        private readonly ServiceContext _context;

        public AccountController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            List<Role> roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            ViewData["Role"] = new SelectList(roles);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            List<Role> roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            ViewData["Role"] = new SelectList(roles);
            if (ModelState.IsValid)
            {
                Client user = await _context.Clients.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password && u.Role == model.Role);
                Master master = await _context.Masters.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password && u.Role == model.Role);
                if (user != null || master != null)
                {
                    await Authenticate(model.Email, model.Role); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Client user = await _context.Clients.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пclользователя в бд
                    _context.Clients.Add(new Client { Email = model.Email, Password = model.Password, LastName = model.LastName, FirstMidName = model.FirstMidName, PhoneNumber = model.PhoneNumber, Role = Role.Клиент.ToString() });
                    await _context.SaveChangesAsync();

                    await Authenticate(model.Email, model.Role); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName, string userRole)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}