using INV_APPLICATION.Data;
using INV_APPLICATION.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
namespace INV_APPLICATION.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _Context;
        public UserController(ApplicationDbContext Context)
        {
            this._Context = Context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var GotUser = _Context.TbUser.Include(x =>x.Rol).ToList();

            return View(GotUser);
        }




        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var UserGot = _Context.TbUser.FirstOrDefault(x => x.Id == id);
            return View(UserGot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                var UserGot = _Context.TbUser.FirstOrDefault(X => X.Id == user.Id);
                if (UserGot == null)
                {
                    return NotFound();
                }
                UserGot.UserName = user.UserName;
                UserGot.Password = user.Password;
                UserGot.RolId = user.RolId;
                UserGot.Name = user.Name;
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Context.TbUser.Add(user);
                    _Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(user); // Mostrar el formulario con errores de validación
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el usuario.");
                return View(user); // Mostrar el formulario con mensaje de error
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {

            var UserGot = _Context.TbUser.FirstOrDefault(x => x.Id == id);
            return View(UserGot);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var UserGot = _Context.TbUser.FirstOrDefault(x => x.Id == id);
            return View(UserGot);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(User user)
        {
            try
            {
                _Context.TbUser.Remove(user);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();

            }
        }
    }
}
