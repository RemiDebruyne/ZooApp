using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCore.Species
{
    public abstract class Species
    {
        public abstract List<Animal> Animals { get; }
    }
}
