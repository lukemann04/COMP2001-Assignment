using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class LogInCount
    {
        public int UserId { get; set; }
        public int? VisitCount { get; set; }
    }
}
