using PetApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApp.Web.Models
{
    public class PetAppVM
    {
        public List<Pet> Pets { get; set; }
        public List<Volunteer> Volunteers { get; set; }
        public List<Shelter> Shelters { get; set; }
    }
}