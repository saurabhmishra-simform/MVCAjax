using ProductMVCDemoAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCDemoAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDBEntities2 _context = new ProductDBEntities2();

        // GET: Home
        public ActionResult Index()
        {
            
            return View(_context.Products.ToList());
        }
        [HttpPost]
        public ActionResult Index(string q)
        {

            if (string.IsNullOrEmpty(q) == false)
            {
                List<Product> productSearch = _context.Products.Where(model => model.ProductName.StartsWith(q)).ToList();
                return PartialView("SearchData", productSearch);
            }
            else
            {
                List<Product> productSearch = _context.Products.ToList();
                return PartialView("SearchData", productSearch);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            using (_context)
            {
                if (ModelState.IsValid == true)
                {
                    _context.Products.Add(product);
                    int res = _context.SaveChanges();
                    if (res > 0)
                    {
                        return Json("Data Inserted !!");
                    }
                    else
                    {
                        return Json("Data not Inserted !!");
                    }
                }
            }  
            return View();
        }
    }
}