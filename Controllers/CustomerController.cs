using INV_APPLICATION.Models;
using INV_APPLICATION.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace INV_APPLICATION.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
           return View(_customerRepository.GetAll());
        }
        public ActionResult Details(int id)
        {
            var customer = _customerRepository.GetById(id);
            return customer == null ? NotFound() : View(customer);
        }

        public ActionResult Create() => View();
        public ActionResult Sales() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            return customer == null ? NotFound() : View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.Update(customer);
                    return RedirectToAction(nameof(Index));
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar el cliente: " + ex.Message);
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            return customer == null ? NotFound() : View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _customerRepository.Delete(_customerRepository.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar el cliente: " + ex.Message);
                return View();
            }
        }
    }
}
