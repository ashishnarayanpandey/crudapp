using crudapp.Models;
using Microsoft.EntityFrameworkCore;

namespace crudapp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sinup_Login> sinup_Logins { get; set; }
    }
    
}
