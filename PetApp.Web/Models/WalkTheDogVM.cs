using PetApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApp.Web.Models
{
    public class WalkTheDogVM
    {
        public string dogName { get; set; }
        public Volunteer Volunteer { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
       
    }
}