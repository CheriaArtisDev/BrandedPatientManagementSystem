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

            var service = new DoctorService();
            service.CreateDoctor(model);
            return RedirectToAction("Index");
        }
    }
}