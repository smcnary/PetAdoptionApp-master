using PetApp.Data;
using PetApp.DataModels;
using PetApp.Web.Adapters.Interfaces;
using PetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApp.Web.Adapters.DataAdapter
{
    public class PetAdapter : IPetAdapter
    {
        public List<Pet> GetPets(PetType filter)
        {
            List<Pet> pets;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (filter == PetType.All)
                {
                    pets = db.Pets.Include("Shelter").OrderBy(x => x.Name).ToList();
                }
                else
                {
                    pets = db.Pets.Include("Shelter").Where(x => x.Type == filter).ToList();
                }

            }

            return pets;
        }

        public Pet GetPet(int Id)
        {
            Pet myPet;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                myPet = db.Pets.Where(x => x.Id == Id).FirstOrDefault();
            }

            return myPet;
        }

        public Pet GetPetByName(string petName)
        {
            Pet myPet;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                myPet = db.Pets.Where(x => x.Name == petName).FirstOrDefault();
            }

            return myPet;
        }

        public void EditPet(Pet pet)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet oldPet = db.Pets.Where(x => x.Id == pet.Id).FirstOrDefault();

                oldPet.Name = pet.Name;
                oldPet.Adopted = pet.Adopted;
                oldPet.Type = pet.Type;

                db.SaveChanges();
            }
        }

        public void AddPet(Pet pet)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Pets.Add(pet);
                db.SaveChanges();
            }
        }

        public void DeletePet(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet deleteMe = db.Pets.Find(Id);
                db.Pets.Remove(deleteMe);

                db.SaveChanges();
            }
        }

        //------------------------------------------

        public List<Shelter> GetShelters(int page)
        {
            List<Shelter> shelters;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                shelters = db.Shelters
                                .OrderBy(x => x.Name)
                                .Skip(3 * page)
                                .Take(3).ToList();
            }

            return shelters;
        }

        public Shelter GetShelter(int Id)
        {
            Shelter shelter;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                shelter = db.Shelters.Include("Pets").Where(x => x.Id == Id).FirstOrDefault();
            }

            return shelter;
        }

        public void EditShelter(Shelter shelter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Shelter oldShelter = db.Shelters.Find(shelter.Id);

                oldShelter.Name = shelter.Name;
                oldShelter.Location = shelter.Location;
                oldShelter.Pets = shelter.Pets;

                db.SaveChanges();
            }
        }

        public void AddShelter(Shelter shelter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Shelters.Add(shelter);
                db.SaveChanges();
            }
        }

        public void DeleteShelter(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Shelter deleteMe = db.Shelters.Find(Id);
                db.Shelters.Remove(deleteMe);

                db.SaveChanges();
            }
        }

        //----------------------------------------

        public void AddVolunteer(Volunteer volunteer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
            }
        }

        public void WantsToAdopt(AdoptVM adopt)
        {
            Volunteer volunteer = new Volunteer();

            volunteer.FirstName = adopt.FirstName;
            volunteer.LastName = adopt.LastName;
            volunteer.Type = VolunteerType.Adopter;
            volunteer.RequestedStart = DateTime.Now;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                volunteer.Pet = db.Pets.Find(adopt.PetId);

                db.Volunteers.Add(volunteer);

                db.SaveChanges();

            }
        }

        public void PopulateAdmin(PetAppVM information)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                information.Pets = db.Pets.ToList();
                information.Shelters = db.Shelters.ToList();
                information.Volunteers = db.Volunteers.ToList();
            }
        }

        public Volunteer GetVolunteer(int Id)
        {
            Volunteer volunteer;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                volunteer = db.Volunteers.Include("Pet").Include("Detail").Where(x => x.Id == Id).FirstOrDefault();
            }

            return volunteer;
        }

        public void DeleteVolunteer(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Volunteer deleteMe = db.Volunteers.Find(Id);
                db.Volunteers.Remove(deleteMe);

                db.SaveChanges();
            }
        }

        public void EditVolunteer(Volunteer volunteer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Volunteer oldVol = db.Volunteers.Find(volunteer.Id);

                oldVol.FirstName = volunteer.FirstName;
                oldVol.LastName = volunteer.LastName;

                db.SaveChanges();
            }
        }

        public void RejectVolunteer(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Volunteer volunteer = db.Volunteers.Find(Id);
                volunteer.Status = Status.Rejected;
                db.SaveChanges();
            }
        }

        public void ApproveVolunteer(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Volunteer him = db.Volunteers
                                    .Include("Pet")
                                    .Include("Detail")
                                    .Where(x => x.Id == Id)
                                    .FirstOrDefault();

                him.Status = Status.Approved;

                if (him.Type == VolunteerType.Adopter)
                {
                    Pet adopted = db.Pets.Find(him.Pet.Id);
                    adopted.Adopted = true;

                }
                else
                {
                    Pet goingWalking = db.Pets.Find(him.Pet.Id);
                    Schedule schedule = new Schedule();

                    schedule.Pet = goingWalking;
                    schedule.PetId = goingWalking.Id;
                    schedule.Volunteer = him;
                    schedule.VolunteerId = him.Id;
                    schedule.StartTime = him.Detail.StartDate;
                    schedule.EndTime = him.Detail.EndDate;

                    schedule.calcAvailability();
                    db.Schedules.Add(schedule);
                }

                db.SaveChanges();
            }
        }

        public void WalkRequest(WalkTheDogVM request)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                Pet pet = db.Pets.Where(x => x.Name == request.dogName).FirstOrDefault();

                Volunteer newVol = new Volunteer();

                newVol.FirstName = request.Volunteer.FirstName;
                newVol.LastName = request.Volunteer.LastName;
                newVol.Pet = pet;
                newVol.RequestedStart = DateTime.Now;
                DateTime ending = request.Time.AddMinutes(30);
                newVol.Detail =
                    new Detail()
                    {
                        StartDate = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day, request.Time.Hour, request.Time.Minute, request.Time.Second),
                        EndDate = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day, ending.Hour, ending.Minute, ending.Second),

                    };

                newVol.Type = VolunteerType.Walker;

                db.Volunteers.Add(newVol);

                db.SaveChanges();
            }
        }


        public IEnumerable<Schedule> GetSchedules()
        {
            IEnumerable<Schedule> list;

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                 list = db.Schedules.Include("Pet").Include("Volunteer").ToList();
            }

            return list;
        }


        public IEnumerable<Shelter> GetAllShelters()
        {
            IEnumerable<Shelter> shelters;

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                shelters = db.Shelters.ToList();
            }

            return shelters;
        }


        public Shelter GetShelterByName(string shelterName)
        {
            Shelter shelter;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               shelter = db.Shelters.Include("Pets").Where(x => x.Name == shelterName).FirstOrDefault();
            }

            return shelter;
        }
    }
}