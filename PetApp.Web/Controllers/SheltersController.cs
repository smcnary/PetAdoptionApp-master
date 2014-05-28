using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PetApp.Data;
using PetApp.DataModels;
using PetApp.Web.Adapters.Interfaces;
using PetApp.Web.Adapters.DataAdapter;

namespace PetApp.Web.Controllers
{
    public class SheltersController : ApiController
    {
        IPetAdapter db;

        public SheltersController()
        {
            db = new PetAdapter();
        }

        public SheltersController(IPetAdapter _db)
        {
            db = _db;
        }

        // GET: api/Shelters
        public IEnumerable<Shelter> GetShelters()
        {
            return db.GetAllShelters();
        }

        
    }
}