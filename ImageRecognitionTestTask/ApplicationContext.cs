using Microsoft.EntityFrameworkCore;

namespace ImageRecognitionTestTask
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ImageRecord> Images => Set<ImageRecord>();
        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
        }
    }
}
