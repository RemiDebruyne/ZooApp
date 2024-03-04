using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
	public class SpeciesRepository : GenericRepository<Species>
	{
		public SpeciesRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
