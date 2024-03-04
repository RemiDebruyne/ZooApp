using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooCore
{
    public class Species : BaseModel
    {
        public string Name { get; set; }
        public  List<Animal>? Animals { get; set; }

        public Family? Family { get; set; }

        [JsonIgnore]
        public int? FamilyId {  get; set; }
    }
}
