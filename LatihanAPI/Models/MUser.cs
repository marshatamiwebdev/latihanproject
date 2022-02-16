using System;
using System.Collections.Generic;

#nullable disable

namespace LatihanAPI.Models
{
    public partial class MUser
    {
        public int UserId { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
    }
}
