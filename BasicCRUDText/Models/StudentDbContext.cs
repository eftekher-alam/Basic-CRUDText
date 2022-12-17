using Microsoft.EntityFrameworkCore;

namespace BasicCRUDText.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        { 

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
