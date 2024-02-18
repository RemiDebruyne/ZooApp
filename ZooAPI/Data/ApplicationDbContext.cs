using Microsoft.EntityFrameworkCore;
using ZooCore;

namespace ZooAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(b => b.Size)
                .HasPrecision(37, 2);
            modelBuilder.Entity<Animal>()
                .Property(b => b.Weight)
                .HasPrecision(37, 2);

            var animalList = new List<Animal>()
        {
            new Animal { Id = 1, Name ="Balou", Age= 12, Color="Dark grey", Family=Family.Ursidae , Species=Species.BlackBear},
            new Animal { Id = 2, Name ="Tigrou", Age = 10, Color="Orange", Family=Family.Felin, Species=Species.Tiger},
            new Animal { Id = 3, Name ="USA", Age= 37, Color="Brown", Family=Family.Avian , Species=Species.Eagle},

        };

            modelBuilder.Entity<Animal>().HasData(animalList);

        }

    }


}
