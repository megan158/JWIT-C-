using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWIT_C_.Models
{
    class SpeakerEvent
    {
        public int EventID { get; set; }
        public int SpeakerID { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string GoogleCalendarID { get; set; }

        // Navigation property (not stored in database)
        public Speaker Speaker { get; set; }
    }
}
