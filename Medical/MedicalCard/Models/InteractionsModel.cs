using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalCard.Models
{
    public class InteractionsModel
    {
        public int Id { get; set; }
        public Nullable<int> SpecialistId { get; set; }
        public string SpecialistFirstName { get; set; }
        public string SpecialistLastName { get; set; }
        public string SpecialistPosition { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Diagnose { get; set; }
        public string Zhaloby { get; set; }
        public Nullable<System.DateTime> DateEntered { get; set; }
        public string ClientIIN { get; set; }
    }
}