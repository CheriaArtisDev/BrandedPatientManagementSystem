using BPMS.Data;
using BPMS.Models;
using BPMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPMS.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            var service = new DoctorService();
            var model = service.GetDoctors();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDoctorService();
            if (service.CreateDoctor(model))
            {
                TempData["SaveResult"] = "Your doctor was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Doctor could not be added.");
            return View(model);
        }

        private static DoctorService CreateDoctorService()
        {
            return new DoctorService();
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDoctorService();
            var model = svc.GetDoctorById(id);
            return View(model);
        }
    }
}