using AjaxPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxPost.Controllers
{
    public class AnimalController : Controller
    {
        private ApplicationDbContext _context;

        public AnimalController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Animal
        public ActionResult Index()
        {
            var animals = from b in _context.Animals
                          where b.Name.StartsWith("a")
                          select b;
            return View(animals.ToList());
        }

        
        public JsonResult GetAnimals(string letter)
        {
            var animals = from a in _context.Animals
                          where a.Name.StartsWith(letter)
                          select a;

            return Json(animals, JsonRequestBehavior.AllowGet);
        }
    }
}