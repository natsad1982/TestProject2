using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalCard.Models;

namespace MedicalCard.Controllers
{
    public class HistoryClientsController : Controller
    {
        TestMedicalConnection med = new TestMedicalConnection();
        public ActionResult AddHistoryClientsPartialView(int? id)
        {
            var sl = med.Specialists.ToList();            
            ViewBag.SpecialistList = new SelectList(sl, "Id", "FullName");

            //var interactionss = med.Interactions.Find(id) ?? new InteractionsModel();
            if (id > 0)
            {
                var interactions = med.Interactions.Find(id);
                return PartialView("EditHistoryClients", interactions);
            }
            else
            {
                var sss = new InteractionsModel();
                //return PartialView("EditHistoryClients", sss);
                return PartialView("CreateHistoryClientsPartial", sss);
            }
        }

        [HttpPost]
        public ActionResult PostInteractions(InteractionsModel im)
        {
            if (ModelState.IsValid)
            {

                if (im.Id > 0)
                {
                    var datass = med.Interactions.SingleOrDefault(kk => kk.Id == im.Id);
                    if(datass != null)
                    {
                        datass.SpecialistId = im.SpecialistId;
                        datass.ClientIIN = im.ClientIIN;
                        datass.Diagnose = im.Diagnose;
                        datass.Zhaloby = im.Zhaloby;
                        datass.DateEntered = im.DateEntered;
                        med.SaveChanges();
                    }
                }
                else
                {
                    Interaction datas = new Interaction();
                    datas.SpecialistId = im.SpecialistId;
                    datas.ClientIIN = im.ClientIIN;
                    datas.Diagnose = im.Diagnose;
                    datas.Zhaloby = im.Zhaloby;
                    datas.DateEntered = im.DateEntered;
                    med.Interactions.Add(datas);
                }
                med.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrEditHistoryClients(InteractionsModel interaction)
        {
            if (ModelState.IsValid)
            {

                if (interaction.Id > 0)
                {
                    med.Entry(interaction).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Interaction datas = new Interaction();
                    datas.SpecialistId = interaction.SpecialistId;
                    datas.ClientIIN = interaction.ClientIIN;
                    datas.Diagnose = interaction.Diagnose;
                    datas.Zhaloby = interaction.Zhaloby;
                    datas.DateEntered = interaction.DateEntered;
                    med.Interactions.Add(datas);                    
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
                var ii = med.Interactions.Find(id);
                med.Interactions.Remove(ii);
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