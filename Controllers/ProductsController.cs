using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gummi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Gummi.Controllers
{
    public class ProductsController : Controller
    {
        private GummiContext db = new GummiContext();

        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);

            return View(thisProd);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, decimal price, string origin, IFormFile image)
        {
            byte[] imageArray = new byte[0];
            if (image.Length > 0)
            {
                using (Stream fileStream = image.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    imageArray = ms.ToArray();
                }
            }
            Product newProduct = new Product(name, price, origin, imageArray); 
            db.Products.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(string ProductId, string name, decimal price, string origin, IFormFile image)
        {
            byte[] imageArray = new byte[0];
            if (image.Length > 0)
            {
                using (Stream fileStream = image.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    imageArray = ms.ToArray();
                }
            }
            Product newProduct = new Product(name, price, origin, imageArray);
            newProduct.ProductId = int.Parse(ProductId);
            db.Entry(newProduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = newProduct.ProductId });
        }

        public IActionResult Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        } 

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
