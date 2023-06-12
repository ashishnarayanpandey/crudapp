namespace crudapp.EmpVM
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
