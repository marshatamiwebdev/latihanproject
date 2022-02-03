using System.ComponentModel.DataAnnotations;

namespace LatihanAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
    }
}