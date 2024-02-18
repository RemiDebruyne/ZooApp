using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCore
{
    internal abstract class Animaux
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Size { get; set; }
        public string? Color { get; set; }
        public Family Family { get; set; }
        public Species Species { get; set; }
    }

    public enum Family
    {
        Felin,
        Avian,
        Ursidae,

    } 

    public enum Species
    {
        Tiger,
        Lion,
        BlackBear,
        PolarBear,
        Eagle,
        Parrot,

    }
}
