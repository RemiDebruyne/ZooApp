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


			return _context.Set<Animal>();

		}

		public override async Task<IEnumerable<Animal?>> GetAllAsync(Expression<Func<Animal, bool>> predicate)
		{
			return _context.Set<Animal>().Include(e => e.Species).Include(e => e.Family).Where(predicate);
		}
		public override Task<Animal?> GetAsync(Expression<Func<Animal, bool>> predicate)
		{
			return _context.Set<Animal>().Include(e => e.Species).Include(e =>e.Family).Where(predicate).FirstOrDefaultAsync();
		}
	}
}
