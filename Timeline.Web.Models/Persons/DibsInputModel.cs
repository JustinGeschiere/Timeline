using System.ComponentModel.DataAnnotations;

namespace Timeline.Web.Models.Persons
{
	public class DibsInputModel
	{
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
	}
}
