using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooCore
{
    public class Animal : BaseModel
    {
        [RegularExpression("^[A-Z][a-z]*$")]
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Size { get; set; }
        [RegularExpression("[a-z]*")]
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
