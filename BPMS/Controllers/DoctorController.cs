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

        public ActionResult Edit(int id)
        {
            var service = CreateDoctorService();
            var detail = service.GetDoctorById(id);
            var model = new DoctorEdit
            {
                DoctorId = detail.DoctorId,
                DoctorFirstName = detail.DoctorFirstName,
                DoctorLastName = detail.DoctorLastName,
                DoctorSpecialty = detail.DoctorSpecialty,
                TakingNewPatients = detail.TakingNewPatients
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DoctorEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.DoctorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDoctorService();

            if (service.UpdateDoctor(model))
            {
                TempData["SaveResult"] = "Your Doctor was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Doctor could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDoctorService();
            var model = svc.GetDoctorById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDoctor(int id)
        {
            var service = CreateDoctorService();
            service.DeleteDoctor(id);
            TempData["SaveResult"] = "Your Doctor was deleted";
            
            return RedirectToAction("Index");
        }
    }
}