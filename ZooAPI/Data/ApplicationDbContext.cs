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


			var FamilyList = new List<Family>()
			{
				new Family { Id = 1, Name="Ursidae"},
				new Family { Id = 2, Name="Felin"},
				new Family { Id = 3, Name="Avian"},
			};

			var SpeciesList = new List<Species>()
			{
				new Species { Id = 1, Name = "Tiger", FamilyId = 2},
				new Species { Id = 2, Name = "Lion", FamilyId = 2},
				new Species { Id = 3, Name = "BlackBear", FamilyId = 1},
				new Species { Id = 4, Name = "PolarBear", FamilyId = 1},
				new Species { Id = 5, Name = "Eagle", FamilyId = 3},
			};

			var animalList = new List<Animal>()
			{
			new Animal { Id = 1, Name ="Balou", Age= 12, Color="Dark grey", FamilyId = 1, SpeciesId = 1},
			new Animal { Id = 2, Name ="Tigrou", Age = 10, Color="Orange", FamilyId = 2, SpeciesId = 1},
			new Animal { Id = 3, Name ="USA", Age= 37, Color="Brown body with white head", FamilyId = 3, SpeciesId = 5},

			};


			modelBuilder.Entity<Family>().HasData(FamilyList);
			modelBuilder.Entity<Species>().HasData(SpeciesList);
			modelBuilder.Entity<Animal>().HasData(animalList);

		}

	}


}
