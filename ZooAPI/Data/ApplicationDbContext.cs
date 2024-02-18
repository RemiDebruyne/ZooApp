using Microsoft.EntityFrameworkCore;
using ZooCore;

namespace ZooAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var animalList = new List<Animal>()
        {
            new Animal { Id = 1, Name ="Balou", Age= 12, Color="Dark grey", Family=Family.Ursidae , Species=Species.BlackBear},
            new Animal { Id = 1, Name ="Tigrou", Age = 10, Color="Orange", Family=Family.Felin, Species=Species.Tiger},
            new Animal { Id = 1, Name ="USA", Age= 37, Color="Brown", Family=Family.Avian , Species=Species.Eagle},

        };

            modelBuilder.Entity<Animal>().HasData(animalList);

        }

    }


}
