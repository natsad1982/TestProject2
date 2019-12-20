using MedicalCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalCard.Controllers
{
    public class HomeController : Controller
    {
        TestMedicalConnection med = new TestMedicalConnection();
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataClients()
        {
            
                var cl = med.Clients.ToList();
                return Json(new { data = cl}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DataDoctors()
        {

            var cl = med.Specialists.ToList();
            return Json(new { data = cl }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Doctors()
        {
            return View();
        }
        public ActionResult DataHistoryClients()
        {
            var cl = from ii in med.Interactions
                     join ss in med.Specialists on ii.SpecialistId equals ss.Id into aa                    
                     from xx in aa.DefaultIfEmpty()
                     select new
                     {
                         nId = ii.Id,
                         nDoctorFullName = xx.FullName,
                         nClientFullName = ii.ClientIIN,
                         nDiagnose = ii.Diagnose,
                         nZhaloby = ii.Zhaloby,
                         nDateEntered = ii.DateEntered
                     };
                

            /*var cl = med.Interactions.SqlQuery("" +
                "SELECT s.FirstName AS DoctorFirstName, s.LastName AS DoctorLastName, c.FirstName AS ClientFirstName, c.LastName AS ClientLastName," +
                "i.Diagnose AS Diagnose, i.Zhaloby AS Zhaloby, i.DateEntered AS DateEntered FROM Interactions AS i" +
                " LEFT JOIN Specialists AS s" +
                " LEFT JOIN Clients AS c" +
                " ON i.SpecialistId = s.Id" +
                " ORDER BY i.Id DESC" +
                "").ToList();*/
            return Json(new { data = cl }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult HistoryClients()
        {
            return View();
        }
    }
}