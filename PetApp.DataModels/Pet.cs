using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.DataModels
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PetType Type { get; set; }

        public bool Adopted { get; set; }

        public int ShelterId { get; set; }

        public Shelter Shelter { get; set; }

        public string Photo { get; set; }

        public Pet()
        {
            this.Adopted = false;
        }
    }

    public enum PetType
    {
        Dog = 1,
        Cat,
        Lizard,
        Hamster,
        All
    }
}
