using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bg { get; set; }
        public string Disease { get; set; }
    }
}