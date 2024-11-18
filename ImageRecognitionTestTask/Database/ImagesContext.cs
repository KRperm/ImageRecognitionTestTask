using Microsoft.EntityFrameworkCore;

namespace ImageRecognitionTestTask.Database
{
    public class ImagesContext : DbContext
    {
        public DbSet<ImageRecord> Images => Set<ImageRecord>();
        public ImagesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
        }
    }
}
