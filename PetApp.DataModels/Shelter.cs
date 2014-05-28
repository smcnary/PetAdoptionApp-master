using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.DataModels
{
    public class Shelter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Pet> Pets { get; set; }

        public string Location { get; set; }

        public string Photo { get; set; }

        public Shelter()
        {
            this.Pets = new List<Pet>();
        }
    }
}
