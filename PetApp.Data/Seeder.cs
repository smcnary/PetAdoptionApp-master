using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using PetApp.DataModels;

namespace PetApp.Data
{
    public static class Seeder
    {
        public static void Seed(
            ApplicationDbContext context, 
            bool seedShelter =  true, bool seedPets = true, bool seedVolunteers = true)
        {
            if (seedShelter)
            {
                Seeder.Shelters(context);
            }

            if(seedPets)
            {
                Seeder.Pets(context);
            }

            if(seedVolunteers)
            {
                Seeder.Volunteers(context);
            }
        }

        private static void Shelters(ApplicationDbContext context)
        {
            context.Shelters.AddOrUpdate(
                    s => s.Name,
                    new Shelter() { Name = "BARC Animal Shelter & Adoptions", Location = "3200 Carr St. Houston, TX" },
                    new Shelter() { Name = "Friends For Life No Kill Shelter", Location = "107 E. 22nd St. Houston, TX" },
                    new Shelter() { Name = "Citizens For Animal Protection", Location = "17555 Katy Fwy Houston, TX" },
                    new Shelter() { Name = "Harris County Veterinary", Location = "612 Canino Rd. Houston, TX" },
                    new Shelter() { Name = "Special Pals", Location = "3830 Greenhouse Rd Houston, TX" },
                    new Shelter() { Name = "Texas Wildlife Rehab Coalition", Location = "10801 Hammerly Blvd Houston, TX" }
                );

            context.SaveChanges();

        }

        private static void Pets(ApplicationDbContext context)
        {
            context.Pets.AddOrUpdate(
                    p => p.Name,
                    new Pet() { Name ="butch", ShelterId = 1,Type = PetType.Dog, Photo = "http://news.distractify.com/wp-content/uploads/2014/01/new-userguide-image.jpg"},
                    new Pet() { Name = "Katy", ShelterId = 2, Type = PetType.Dog, Photo =  "http://nodogaboutit.files.wordpress.com/2012/10/j04310181.jpg"},
                    new Pet() { Name = "ronny", ShelterId = 3, Type = PetType.Dog, Photo = "http://images.wisegeek.com/dog-wash.jpg"},

                    new Pet() { Name = "sally", ShelterId = 1, Type = PetType.Cat, Photo = "http://www.petfinder.com/wp-content/uploads/2012/11/99059361-choose-cat-litter-632x475.jpg"},
                    new Pet() { Name = "jane", ShelterId = 2, Type = PetType.Cat, Photo = "http://www.vetprofessionals.com/catprofessional/images/home-cat.jpg"},
                    new Pet() { Name = "farris", ShelterId = 3, Type = PetType.Cat, Photo = "http://www.friskies.com/Content/images/headers/cat_wet.png"},

                    new Pet() { Name = "bruce", ShelterId = 1, Type = PetType.Lizard, Photo = "http://upload.wikimedia.org/wikipedia/commons/1/18/Bartagame_fcm.jpg"},
                    new Pet() { Name = "eve", ShelterId = 2, Type = PetType.Lizard, Photo = "http://yubanet.com/uploads/5/Lizard.jpg"},
                    new Pet() { Name = "steve", ShelterId = 3, Type = PetType.Lizard, Photo = "http://i.livescience.com/images/i/000/054/967/i02/lizard-with-dewlap-flap.jpg?1374169882"},

                    new Pet() { Name = "seth", ShelterId = 1, Type = PetType.Hamster, Photo = "http://ontariospca.ca/blog/wp-content/uploads/2013/09/Hamster.jpg"},
                    new Pet() { Name = "grace", ShelterId = 2, Type = PetType.Hamster, Photo = "http://media.npr.org/assets/img/2011/04/09/hamster-9209e959e92b65fff6e13613565b89f138716794-s6-c30.jpg" },
                    new Pet() { Name = "jim", ShelterId = 3, Type = PetType.Hamster, Photo = "http://www.freeinfosociety.com/media/images/3609.jpg"},

                    new Pet() { Name ="ronald", ShelterId = 1,Type = PetType.Dog, Photo = "http://pad1.whstatic.com/images/thumb/3/37/Pet-a-Dog-Step-1.jpg/670px-Pet-a-Dog-Step-1.jpg" },
                    new Pet() { Name ="harry", ShelterId = 2,Type =PetType.Cat, Photo = "http://explosionhub.com/wp-content/uploads/2012/07/1562-cute-little-cat.jpg"},
                    new Pet() { Name = "steward", ShelterId = 3, Type = PetType.Hamster, Photo = "http://i.telegraph.co.uk/multimedia/archive/01014/hamster-460_1014550c.jpg" }
                );

            context.SaveChanges();
        }

        private static void Volunteers(ApplicationDbContext context)
        {
            context.Volunteers.AddOrUpdate(
                 o => new { o.FirstName, o.LastName },
                 new Volunteer()
                 {
                     FirstName = "Andre'",
                     LastName = "Jones",
                     RequestedStart = DateTime.Now,
                     Status = Status.Pending,
                     Type = VolunteerType.Adopter,
                     Pet = context.Pets.Find(2),
                     Detail = 
                     new Detail
                     {
                         StartDate = DateTime.Now,
                         EndDate = DateTime.Now
                     }
                 }
                );
        }
    }
}
