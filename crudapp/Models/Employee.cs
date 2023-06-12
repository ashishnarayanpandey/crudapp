using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crudapp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }
        public string ImagePath { get; set; }

    }
}
