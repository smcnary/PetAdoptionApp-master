using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.DataModels
{
    public class Schedule
    {
        public int Id { get; set; }

        public int VolunteerId { get; set; }
        public virtual Volunteer Volunteer { get; set; }

        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeSpan Booked { get; set; }

        public void calcAvailability()
        {
            this.Booked = this.EndTime - this.StartTime;
        }
    }
}
