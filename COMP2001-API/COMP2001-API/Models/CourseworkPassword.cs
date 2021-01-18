using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class CourseworkPassword
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public DateTime ChangeTime { get; set; }

        public virtual CourseworkUser User { get; set; }
    }
}
