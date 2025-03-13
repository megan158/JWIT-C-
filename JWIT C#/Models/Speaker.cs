using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWIT_C_.Models
{
    class Speaker
    {
        public int SpeakerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Expertise { get; set; }
        public string Bio { get; set; }
        public string TalkTopic { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }

        // Helper property for display purposes
        public string FullName => $"{FirstName} {LastName}";
    }
}
