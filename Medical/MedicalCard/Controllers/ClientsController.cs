using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalCard.Models;

namespace MedicalCard.Controllers
{
    public class ClientsController : Controller
    {
        TestMedicalConnection med = new TestMedicalConnection();
        // GET: Clients
        public ActionResult AddClientsPartialView(int? id)
        {
            var clients = med.Clients.Find(id) ?? new Client();
            return PartialView("CreateEditClientsPartial", clients);
        }

        public ActionResult AddOrEditClients(Client client)
        {            
            if(ModelState.IsValid)
            {
                if (client.Id > 0)
                {
                    med.Entry(client).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    med.Clients.Add(client);
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
                var clients = med.Clients.Find(id);
                med.Clients.Remove(clients);
                med.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception cc)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}