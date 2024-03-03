using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCore.Families
{
    public abstract class Family
    {
        public  int Id { get; }
        public List<Animal>? Animals { get; }
        public List<Species> Species { get; set; }

    }
}
