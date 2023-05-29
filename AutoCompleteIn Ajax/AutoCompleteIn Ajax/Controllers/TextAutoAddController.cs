using AutoCompleteIn_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace AutoCompleteIn_Ajax.Controllers
{
    public class TextAutoAddController : Controller
    {
        private readonly CompanyEntities _context = new CompanyEntities();
        // GET: TextAutoAdd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetEmployee(string ename)
        {
            var emp = (from x in _context.Employees where x.Name.StartsWith(ename) select new { label = x.Name }).ToList();
            return Json(emp);
        }
        [HttpGet]
        public ActionResult Details(int? i)
        {
            var result = _context.Employees.ToList().ToPagedList(i ?? 1,3);
            return PartialView("_Employees", result);
        }
    }
}