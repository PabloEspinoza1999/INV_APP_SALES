using INV_APPLICATION.Data;
using INV_APPLICATION.Models;
using INV_APPLICATION.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INV_APPLICATION.Controllers
{
    public class SaleController : Controller
    {

        private readonly ApplicationDbContext _Context;
        public SaleController(ApplicationDbContext Context)
        {
            this._Context = Context;
        }
        // GET: SaleController
        public ActionResult Index()
        {
            
                var products = _Context.TbProduct.ToList();
                var customers = _Context.TbCustomer.Include(p => p.Zone).ToList();

            var model =   new ViewModelSale
                {
                    Products = products,
                    Customers = customers
                };

                return View(model);
            

        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
