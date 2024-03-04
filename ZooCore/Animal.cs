using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooCore
{
	public class Animal : BaseModel
	{
		[RegularExpression("[a-z]*$")]
		public string? Name { get; set; }
		public int? Age { get; set; }

		[RegularExpression(@"\d+(\.\d+)?")]
		public decimal? Weight { get; set; }

		[RegularExpression(@"\d+(\.\d+)?")]
		public decimal? Size { get; set; }
		[RegularExpression("[a-z]*")]
		public string? Color { get; set; }
		public Family? Family { get; set; }
		public int FamilyId { get; set; }
		public Species? Species { get; set; }

		public int SpeciesId { get; set; }
	}
}
