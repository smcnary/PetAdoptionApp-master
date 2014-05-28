using PetApp.DataModels;
using PetApp.Web.Adapters.DataAdapter;
using PetApp.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetApp.Web.Controllers
{
    public class AdminController : Controller
    {
        IPetAdapter db;

        public AdminController()
        {
            db = new PetAdapter();
        }

        public AdminController(IPetAdapter _db)
        {
            db = _db;
        }

        public ActionResult Approve(int Id)
        {
            Volunteer model = db.GetVolunteer(Id);

            return View(model);
        }

        [HttpGet]//done
        public ActionResult AddShelter()
        {
            return View();
        }

        [HttpPost]//done
        public ActionResult AddShelter(Shelter shelter)
        {
            db.AddShelter(shelter);
            return RedirectToAction("PetAppAdmin", "Home");
        }

        [HttpGet]
        public ActionResult UpdateShelter(int Id)
        {
            Shelter shelter = db.GetShelter(Id);

            return View(shelter);
        }

        [HttpPost]
        public ActionResult UpdateShelter(Shelter shelter)
        {
            return View();
        }

        [HttpPost]//done
        public ActionResult RemoveShelter(int Id)
        {
            db.DeleteShelter(Id);
            return RedirectToAction("PetAppAdmin", "Home");
        }

        [HttpGet]
        public ActionResult UpdateVolunteer(int Id)
        {
            Volunteer volunteer = db.GetVolunteer(Id);
            
            return View(volunteer);
        }

        [HttpPost]
        public ActionResult UpdateVolunteer(Volunteer volunteer)
        {
            db.EditVolunteer(volunteer);
            return RedirectToAction("PetAppAdmin","Home");
        }

        [HttpPost]//done
        public ActionResult RemoveVolunteer(int Id)
        {
            db.DeleteVolunteer(Id);

            return RedirectToAction("PetAppAdmin", "Home");
        }

        [HttpGet]//done
        public ActionResult AddPet(int Id)
        {
            Pet pet = new Pet();
            pet.ShelterId = Id;

            return View(pet);
        }

        [HttpPost]//done
        public ActionResult AddPet(Pet pet)
        {
            db.AddPet(pet);

            return RedirectToAction("PetAppAdmin", "Home");
        }

        [HttpGet]
        public ActionResult UpdatePet(int Id)
        {
            Pet pet = db.GetPet(Id);
            return View(pet);
        }

        [HttpPost]
        public ActionResult UpdatePet(Pet pet)
        {
            db.EditPet(pet);
            return RedirectToAction("PetAppAdmin", "Home");
        }

        [HttpPost]//done
        public ActionResult RemovePet(int Id)
        {
            db.DeletePet(Id);

            return RedirectToAction("PetAppAdmin", "Home");
        }

        public ActionResult Confirm(int Id, int choic)
        {
            if(choic == 1)
            {
                db.ApproveVolunteer(Id);
            }
            else
            {
                db.RejectVolunteer(Id);
            }

            return RedirectToAction("PetAppAdmin","Home");
        }
    }
}