using INV_APPLICATION.Data;
using INV_APPLICATION.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace INV_APPLICATION.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IWebHostEnvironment _webHostEnvironment;
       public ProductController(ApplicationDbContext Context, IWebHostEnvironment webHostEnvironment)
        {
            this._Context = Context;
            this._webHostEnvironment = webHostEnvironment;

        }
        // GET: ProductController1
        public ActionResult Index()
        {
            var Products = _Context.TbProduct.ToList();
     
            return View(Products);
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            var ProductGot = _Context.TbProduct.FirstOrDefault(i=>i.Id==id);
            return View(ProductGot);
        }

        [HttpPost]
        public ActionResult Filtrar(string texto)
        {
            // Filtrar los productos cuyo nombre contenga el texto proporcionado
            var productosFiltrados = _Context.TbProduct
                .Where(p => p.ProductName.Contains(texto)).Select(p => p.ProductName).ToList();

            // Devolver los nombres de los productos filtrados en formato JSON
            return Json(productosFiltrados);
        }


        [HttpPost]
        public ActionResult Buscar(string texto)
        {
            // Filtrar los productos cuyo nombre contenga el texto proporcionado
            var productosFiltrados = _Context.TbProduct.FirstOrDefault(x=>x.ProductCode=="000028");

            // Devolver los nombres de los productos filtrados en formato JSON
            return Json(productosFiltrados);
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {
            return View();
        }




        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product ProductNow)
        {
            try
            {
                if (ModelState.IsValid) // Verificar si el modelo es válido antes de procesar
                {

                    var ProductForm = SaveImgLocal(ProductNow);
                    _Context.Add(ProductForm);
                    _Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Si el modelo no es válido, retorna la vista con los errores de validación
                    return View(ProductNow);
                }
            }
            catch (Exception ex)
            {
                // Loguear la excepción para propósitos de debugging
                Console.WriteLine("Error en la creación del producto: " + ex.Message);
                // Redirigir a una vista de error personalizada o mostrar un mensaje de error
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: ProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            var ProductGot = _Context.TbProduct.FirstOrDefault(x => x.Id == id);
            return View(ProductGot);
        }

        // POST: ProductController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product ProductNow)
        {
            try
            {
                var ProductGot = _Context.TbProduct.FirstOrDefault(x => x.Id == id);
             
                if (ProductGot == null)
                {
                    return NotFound();
                }
                var ProductForm = SaveImgLocal(ProductNow);

                ProductGot.ProductName = ProductNow.ProductName;
                ProductGot.Price = ProductNow.Price;
                ProductGot.Description = ProductNow.Description;
                ProductGot.Stock = ProductForm.Stock;
                ProductGot.ImgUrl = ProductForm.ImgUrl;
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            var ProductGot = _Context.TbProduct.FirstOrDefault(x => x.Id == id);
            return View(ProductGot);
        }

        // POST: ProductController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Product ProductNow)
        {
            try
            {
                var ProductGot = _Context.TbProduct.FirstOrDefault(x=>x.Id==id);
                if (ProductGot == null)
                {
                   return NotFound();
                }
                _Context.TbProduct.Remove(ProductGot);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


       public Product SaveImgLocal(Product ProductNow)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            string upload = Path.Combine(webRootPath, WC.ImagenRuta); // Utilizar Path.Combine para concatenar rutas de manera segura
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            string filePath = Path.Combine(upload, fileName + extension); // Crear la ruta completa del archivo

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            ProductNow.ImgUrl = fileName + extension;

            return ProductNow;
        }
    }
}
