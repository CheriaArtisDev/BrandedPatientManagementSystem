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

        public ActionResult Edit(int id)
        {
            var service = CreatePatientService();
            var detail = service.GetPatientById(id);
            var model = new PatientEdit
            {
                PatientId = detail.PatientId,
                PatientFirstName = detail.PatientFirstName,
                PatientLastName = detail.PatientLastName,
                PatientAge = detail.PatientAge,
                PatientAddress = detail.PatientAddress,
                PatientPhoneNumber = detail.PatientPhoneNumber,
                PatientBirthdate = detail.PatientBirthdate,
                PatientGender = detail.PatientGender,
                DoctorName = detail.DoctorName,
                DoctorId = detail.DoctorId,
                HasInsurance = detail.HasInsurance,
                MaritalStatus = detail.MaritalStatus
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientEdit model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.PatientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePatientService();

            if(service.UpdatePatient(model))
            {
                TempData["SaveResult"] = "Your Patient was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Patient could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePatientService();
            var model = svc.GetPatientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatient(int id)
        {
            var service = CreatePatientService();
            service.DeletePatient(id);
            TempData["SaveResult"] = "Your patient was deleted.";
            return RedirectToAction("Index");
        }
    }
}