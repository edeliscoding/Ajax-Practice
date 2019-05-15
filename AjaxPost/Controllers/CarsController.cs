using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;


using System.Web.Mvc;
using AjaxPost.Models;
using AjaxPost.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace AjaxPost.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Cars
        [Authorize]
        public ActionResult Index()
        {
            var carViewModel = new CarViewModel()
            {
                Cars = db.Cars.ToList()
            };
            return View(carViewModel);
        }

        [HttpPost]
        public JsonResult Search(Car car)
        {
            var model = db.Cars.Single(m => m.Id == car.Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CarSearch(List<Car> Cars)
        {
            var usernameId = User.Identity.GetUserId();
            var username = db.Users.Single(u => u.Id == usernameId);

            foreach (Car Carsingle in Cars)
            {
                var newCars = new Car
                {
                    Name = Carsingle.Name,
                    Employee = username
                };
                //Console.WriteLine(Carsingle);
                //db.SaveChanges();
                //Car existing = db.Cars.SingleOrDefault();
                //existing.Name = Carsingle.Name;
                db.Cars.Add(newCars);
            }

            db.SaveChanges();
            return RedirectToAction("Mine", "Cars");

       

        }
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userId);
            var cars = db.Cars.Where(c => c.Employee.Id == userId && c.Name != null).ToList();

            return View(cars);
            //var car = new Car
            //{
            //    Employee = user,
            //    Cars = cars
            //};
            //return View(car);
        }


        [HttpPost]
        public JsonResult EditCar(List<Car> Cars)
        {
            var usernameId = User.Identity.GetUserId();
            var username = db.Users.Single(u => u.Id == usernameId);

            foreach (Car carList in Cars)
            {
                var carId = db.Cars.Single(c => c.Id == carList.Id);
                carId.Id = carList.Id;
                carId.Name = carList.Name;
                carId.Employee = username;
                var editCars = new Car()
                {
                    Id = carList.Id,
                    Name = carList.Name,
                    Employee = username
                };

            }
            db.SaveChanges();
            return Json(Cars, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost] Original
        //public ActionResult EditCar(List<Car> Cars)
        //{
        //    var usernameId = User.Identity.GetUserId();
        //    var username = db.Users.Single(u => u.Id == usernameId);

        //    foreach (Car carList in Cars)
        //    {
        //        var carId = db.Cars.Single(c => c.Id == carList.Id);
        //        carId.Id = carList.Id;
        //        carId.Name = carList.Name;
        //        carId.Employee = username;
        //        var editCars = new Car()
        //        {
        //            Id = carList.Id,
        //            Name = carList.Name,
        //            Employee = username
        //        };

        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Cars");
        //}
        //[HttpPost]
        //public ActionResult CarEdit(List<Car> Cars)
        //{
        //    var usernameId = User.Identity.GetUserId();
        //    var username = db.Users.Single(u => u.Id == usernameId);
        //    //var carId = db.Cars.Where(c => c.Id == Cars.Id).ToList();

        //    foreach (Car editcar in Cars)
        //    {
        //        var editCars = new Car()
        //        {
        //            Id = editcar.Id,
        //            Employee = username,
        //            Name = editcar.Name
        //        };
        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}
