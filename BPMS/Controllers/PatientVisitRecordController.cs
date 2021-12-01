using BPMS.Models;
using BPMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPMS.Controllers
{
    [Authorize]
    public class PatientVisitRecordController : Controller
    {
        // GET: PatientVisitRecord
        public ActionResult Index()
        {
            var service = new PatientVisitRecordService();
            var model = service.GetPatientVisitRecords();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientVisitRecordCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePatientVisitRecordService();

            if (service.CreatePatientVisitRecord(model))
            {
                TempData["SaveResult"] = "Your Patient Visit Record was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Patient Visit Record could not be created.");
            return View(model);
        }

        private static PatientVisitRecordService CreatePatientVisitRecordService()
        {
            return new PatientVisitRecordService();
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePatientVisitRecordService();
            var model = svc.GetPatientVisitRecordsById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePatientVisitRecordService();
            var detail = service.GetPatientVisitRecordsById(id);
            var model = new PatientVisitRecordEdit
            {
                RecordId = detail.RecordId,
                TestsScheduled = detail.TestsScheduled,
                TestResults = detail.TestResults,
                AppointmentDate = detail.AppointmentDate,
                DoctorsNotes = detail.DoctorsNotes,
                Prognosis = detail.Prognosis,
                PatientHeight = detail.PatientHeight,
                PatientWeight = detail.PatientWeight,
                DoctorId = detail.DoctorId,
                PatientId = detail.PatientId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientVisitRecordEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.RecordId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePatientVisitRecordService();

            if (service.UpdatePatientVisitRecord(model))
            {
                TempData["SaveResult"] = "Your Patient Visit Record was edited.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Patient Visit Record could not be edited.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePatientVisitRecordService();
            var model = svc.GetPatientVisitRecordsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatientVisitRecord(int id)
        {
            var service = CreatePatientVisitRecordService();
            service.DeletePatientVisitRecord(id);
            TempData["SaveResult"] = "Your patient visit record was deleted.";
            return RedirectToAction("Index");
        }
    }
}