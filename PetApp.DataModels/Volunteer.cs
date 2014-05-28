using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.DataModels
{
    public class Volunteer
    {
        public Volunteer()
        {
            this.Status = Status.Pending;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public VolunteerType Type { get; set; }
        public virtual Pet Pet { get; set; }
        public DateTime RequestedStart { get; set; }
        public Status Status { get; set; }
        
        public virtual Detail Detail { get; set; }

        public string Message()
        {
                string intent = "";

                if (this.Type == VolunteerType.Walker)
                {
                    intent = this.FirstName + " wants to walk " + this.Pet.Name + " " + this.Detail.StartDate.ToShortDateString() + " at " + this.Detail.StartDate.ToShortTimeString();

                }
                else
                {
                    intent = this.FirstName + " wants to adopt " + this.Pet.Name + ". Request was submited on " + this.RequestedStart.ToShortDateString();
                }

                return intent;
            
        }
    }

    public enum VolunteerType
    {
        Adopter = 1,
        Walker,
    }

    public enum Status
    {
        Pending = 1,
        Approved,
        Rejected,
    }
}
