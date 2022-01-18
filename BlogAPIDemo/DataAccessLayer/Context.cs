using Microsoft.EntityFrameworkCore;

namespace BlogAPIDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("server=GAME1515; database=CoreBlogDb; integrated security=true;");
            //  optionsBuilder.UseSqlServer("server=AB01500-5000; database=CoreBlogDb; integrated security=true;");
            optionsBuilder.UseSqlServer("server=BURDUR; database=CoreBlogApiDb; integrated security=true;");

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
