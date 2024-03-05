using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
	public class AnimalRepository : GenericRepository<Animal>
	{
		public AnimalRepository(ApplicationDbContext context) : base(context)
		{
		}


		public override async Task<IEnumerable<Animal?>> GetAllAsync()
		{


			return _context.Set<Animal>().Include(e => e.Family).Include(e => e.Species);

		}

		public override async Task<IEnumerable<Animal?>> GetAllAsync(Expression<Func<Animal, bool>> predicate)
		{
			return _context.Set<Animal>().Include(e => e.Species).Include(e => e.Family).Where(predicate);
		}
		public override Task<Animal?> GetAsync(Expression<Func<Animal, bool>> predicate)
		{
			return _context.Set<Animal>().Include(e => e.Species).Include(e =>e.Family).Where(predicate).FirstOrDefaultAsync();
		}

		public override async Task<bool> UpdateAsync(Animal entity)
		{
			var entityFromDb = await GetAsync(e => e.Id == entity.Id);

			if (entityFromDb == null)
				return false;

			if (entityFromDb.Name != entity.Name)
				entityFromDb.Name = entity.Name;
			if (entityFromDb.Age != entity.Age)
				entityFromDb.Age = entity.Age;
			if (entityFromDb.Weight != entity.Weight)
				entityFromDb.Weight = entity.Weight;
			if (entityFromDb.Size != entity.Size)
				entityFromDb.Size = entity.Size;
			if (entityFromDb.Color != entity.Color)
				entityFromDb.Color = entity.Color;
			if (entityFromDb.FamilyId != entity.FamilyId)
				entityFromDb.FamilyId = entity.FamilyId;
			if (entityFromDb.SpeciesId != entity.SpeciesId)
				entityFromDb.SpeciesId = entity.SpeciesId;

			return await _context.SaveChangesAsync() > 0;
		}
	}
}
