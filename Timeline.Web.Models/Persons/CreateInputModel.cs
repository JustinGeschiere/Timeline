using System.ComponentModel.DataAnnotations;

namespace Timeline.Web.Models.Persons
{
	public class CreateInputModel
	{
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
	}
}
