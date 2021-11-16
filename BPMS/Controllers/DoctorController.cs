using BPMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPMS.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            var model = new Doctor[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}