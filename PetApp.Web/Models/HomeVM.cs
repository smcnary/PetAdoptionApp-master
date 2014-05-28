using PetApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApp.Web.Models
{
    public class HomeVM
    {
        public Pet FeaturedPet { get; set; }
        public List<Shelter> Shelters { get; set; }
        public List<Pet> Pets { get; set; }
        public int Page { get; set; }

        public void SetFeaturedPet()
        {
            Random r = new Random();
            int rInt = r.Next(1, this.Pets.Count);
            this.FeaturedPet = this.Pets[rInt];
        }
    }
}