using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCore
{
    public class Family : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Animal>? Animals { get; set; }
        public List<Species>? Species { get; set; }

    }
}
