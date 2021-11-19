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
    public class PatientController : Controller
    {
        [Authorize]
        // GET: Patient
        public ActionResult Index()
        {
            var service = new PatientService();
            var model = service.GetPatients();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePatientService();

            if (service.CreatePatient(model))
            {

                TempData["SaveResult"] = "Your Patient was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Patient could not be created.");
            return View(model);
        }

        private static PatientService CreatePatientService()
        {
            return new PatientService();
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePatientService();
            var model = svc.GetPatientById(id);
            return View(model);
        }
    }
}