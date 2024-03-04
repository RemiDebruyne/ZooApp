using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
	public class FamilyRepository : GenericRepository<Family>
	{
		public FamilyRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
