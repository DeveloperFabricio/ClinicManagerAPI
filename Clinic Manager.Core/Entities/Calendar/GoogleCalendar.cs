using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Manager.Core.Entities.Calendar
{
    public class GoogleCalendar
    {
        public GoogleCalendar(string summary,
            string description, 
            string location, 
            DateTime start, 
            DateTime end)

        {
            Summary = summary;
            Description = description;
            Location = location;
            Start = start;
            End = end;
        }

        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

}

