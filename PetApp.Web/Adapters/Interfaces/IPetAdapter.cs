using PetApp.DataModels;
using PetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.Web.Adapters.Interfaces
{
    public interface IPetAdapter
    {
        List<Pet> GetPets(PetType filter);

        Pet GetPet(int Id);

        Pet GetPetByName(string petName);

        void EditPet(Pet pet);

        void AddPet(Pet pet);

        void DeletePet(int Id);


        List<Shelter> GetShelters(int page);

        Shelter GetShelter(int Id);

        void EditShelter(Shelter shelter);

        void AddShelter(Shelter shelter);

        void DeleteShelter(int Id);

        Volunteer GetVolunteer(int Id);

        void AddVolunteer(Volunteer volunteer);

        void WantsToAdopt(AdoptVM adopt);

        void PopulateAdmin(PetAppVM information);

        void DeleteVolunteer(int Id);

        void EditVolunteer(Volunteer volunteer);

        void RejectVolunteer(int Id);

        void ApproveVolunteer(int Id);

        void WalkRequest(WalkTheDogVM request);

        IEnumerable<Schedule> GetSchedules();

        IEnumerable<Shelter> GetAllShelters();

        Shelter GetShelterByName(string shelterName);
    }
}
