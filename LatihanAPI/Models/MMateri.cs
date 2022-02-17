using System;
using System.Collections.Generic;

#nullable disable

namespace LatihanAPI.Models
{
    public partial class Mmateri
    {
        public int MateriId { get; set; }
        public string MateriTitle { get; set; }
        public string MateriDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
        public string Remarks { get; set; }
    }
}
