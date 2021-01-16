using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_Coursework_API.Models
{
    public partial class CourseworkUser
    {
        public CourseworkUser()
        {
            CourseworkSessions = new HashSet<CourseworkSession>();
        }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public virtual CourseworkPassword CourseworkPassword { get; set; }
        public virtual ICollection<CourseworkSession> CourseworkSessions { get; set; }
    }
}
