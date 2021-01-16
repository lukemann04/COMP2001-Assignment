using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_Coursework_API.Models
{
    public partial class CourseworkSession
    {
        public int SessionId { get; set; }
        public int? UserId { get; set; }
        public DateTime SessionTime { get; set; }

        public virtual CourseworkUser User { get; set; }
    }
}
