using INV_APPLICATION.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using INV_APPLICATION.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace INV_APPLICATION.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public AccessController(ApplicationDbContext Context)
        {
            this._Context = Context;
        }
        // GET: AccessController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Log(User user)
        {
            try
            {
                var MyUser = await _Context.TbUser.FirstOrDefaultAsync(v => v.UserName == user.UserName && v.Password == user.Password);

                if (MyUser != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, MyUser.Name),
                        new Claim("UserName", MyUser.UserName)
                 };

                var roles = await _Context.TbRol.Select(x=>x.RolName).ToListAsync();

                foreach (string role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Sale");
            }
        else
            {
                return View(); // Aquí deberías redirigir a una vista de error de autenticación.
            }
        }
    catch (Exception ex)
    {
        // Manejo de errores: Registra el error y redirige a una vista de error.
        //_logger.LogError(ex, "Error durante el inicio de sesión.");
        return RedirectToAction("Error", "Home");
    }
}


public async Task<IActionResult> UnLog()
        {
            // Sign out the current user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect the user to the home page
            return RedirectToAction("Index", "Access");

        }



    }
}
