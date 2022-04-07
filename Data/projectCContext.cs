using Microsoft.EntityFrameworkCore;
using projectC.Models;
namespace projectC.Data
{
    public class projectCContext : DbContext
    {
        public projectCContext (DbContextOptions<projectCContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        
    }
    
}