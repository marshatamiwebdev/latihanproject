using System;
using System.Collections.Generic;

#nullable disable

namespace LatihanAPI.Models
{
    public partial class Mteacher
    {
        public int TeacherId { get; set; }
        public string TeacherCode { get; set; }
        public int? UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
        public string Remarks { get; set; }
    }
}
