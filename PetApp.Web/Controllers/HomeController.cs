using PetApp.DataModels;
using PetApp.Web.Adapters.DataAdapter;
using PetApp.Web.Adapters.Interfaces;
using PetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetApp.Web.Controllers
{
    public class HomeController : Controller
    {
        IPetAdapter db;

        public HomeController()
        {
            db = new PetAdapter();
        }

        public HomeController(IPetAdapter _db)
        {
            db = _db;
        }

        public ActionResult Index(int page = 0, PetType filter = PetType.All)
        {
            ViewData["message"] = TempData["message"];

            HomeVM model = new HomeVM();

            model.Pets = db.GetPets(filter);

            model.SetFeaturedPet();

            model.Shelters = db.GetShelters(page);

            model.Page = page + 1;

            return View(model);
        }

        public ActionResult PetDetail(string petName)
        {
            Pet pet = db.GetPetByName(petName);
            
            return View(pet);
        }

        [HttpGet]
        public ActionResult Adoption(string petName)
        {
            Pet pet = db.GetPetByName(petName);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Adoption(AdoptVM adopt)
        {
            db.WantsToAdopt(adopt);
            TempData["message"] = "Pending approval";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Walk(string dogName)
        {
            WalkTheDogVM walkem = new WalkTheDogVM();

            walkem.dogName = dogName;

            return View(walkem);
        }

        [HttpPost]
        public ActionResult Walk(WalkTheDogVM request)
        {
            db.WalkRequest(request);
            TempData["message"] = "Pending approval";
            return RedirectToAction("Index");
        }

        public ActionResult PetAppAdmin()
        {
            PetAppVM information = new PetAppVM();

            db.PopulateAdmin(information);

            return View(information);
        }

        public ActionResult Shelter(int Id)
        {
            Shelter shelter = db.GetShelter(Id);

            return View(shelter);
        }
    }
}