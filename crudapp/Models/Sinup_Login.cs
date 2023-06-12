using System.ComponentModel.DataAnnotations;

namespace crudapp.Models
{
    public class Sinup_Login
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public long? phone { get; set; }
        public bool IsActive { get; set; }
    }
}
