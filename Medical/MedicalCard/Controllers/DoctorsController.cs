using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalCard.Models;

namespace MedicalCard.Controllers
{
    public class DoctorsController : Controller
    {
        TestMedicalConnection med = new TestMedicalConnection();
        // GET: Doctors
        public ActionResult AddDoctorsPartialView(int? id)
        {
            var doctors = med.Specialists.Find(id) ?? new Specialist();
            return PartialView("CreateEditDoctorsPartial", doctors);
        }
        public ActionResult AddOrEditDoctors(Specialist doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.Id > 0)
                {
                    med.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    doctor.FullName = doctor.FirstName + " " + doctor.LastName;
                    med.Specialists.Add(doctor);
                }

                med.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var doctors = med.Specialists.Find(id);
                med.Specialists.Remove(doctors);
                med.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch(Exception cc)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}