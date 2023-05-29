using AjaxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDBEntities _context = new ProductDBEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AllProducts()
        {
            int num = 3;
            Session["data"] = num;
            var data = _context.Products.ToList().Take(num);
            return PartialView("_Products", data);
        }
        [HttpGet]
        public ActionResult Top3Product()
        {
            var data = _context.Products.OrderByDescending(p => p.Price).Take(3).ToList();
            return PartialView("_Products",data);
        }
        [HttpGet]
        public ActionResult Buttom3Product()
        {
            var data = _context.Products.OrderBy(p => p.Price).Take(3).ToList();
            return PartialView("_Products",data);
        }

        [HttpPost]
        public ActionResult LoadMore()
        {
            int rows = Convert.ToInt32(Session["data"]) + 3;
            var data = _context.Products.ToList().Take(rows);
            Session["data"] = rows;
            return PartialView("_Products",data);
        }
        [HttpPost]
        public ActionResult LoadPrev()
        {
            int rows = Convert.ToInt32(Session["data"]) - 3;
            var data = _context.Products.ToList().Take(rows);
            Session["data"] = rows;
            return PartialView("_Products", data);
        }
    }
}