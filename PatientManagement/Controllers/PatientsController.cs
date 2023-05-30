using PatientManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagement.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ViewResult Index()
        {
            PatientModelManager db = new PatientModelManager();
            List<Patient> patients = db.GetPatients();
            return View(patients);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            PatientModelManager db = new PatientModelManager();
            int rowInserted = db.AddPatient(patient);
            if (rowInserted >= 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            PatientModelManager db = new PatientModelManager();
            Patient patient = db.GetPatientById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            PatientModelManager db = new PatientModelManager();
            int updatedRow = db.UpdatePatient(patient);
            if (updatedRow >= 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            PatientModelManager db = new PatientModelManager();
            Patient patient = db.GetPatientById(id);
            return View(patient);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientModelManager db = new PatientModelManager();
            int rowsDeleted = db.DeletePatient(id);
            if (rowsDeleted >= 1)
            {
                return RedirectToAction("Index");
            }
             return View();
        }
    }
}