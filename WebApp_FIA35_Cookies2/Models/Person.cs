using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_FIA35_Cookies2.Models
{
    public class Person
    {
        [Display(Name ="Vorname")]
        public string Vorname { get; set; }

        [Display(Name = "Nachname")]
        public string Nachname { get; set; }

        [Display(Name = "Alter")]
        public int Alter { get; set; }

    }
}
