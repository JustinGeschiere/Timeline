using System.ComponentModel.DataAnnotations;

namespace Timeline.Web.Models.Persons
{
	public class DeleteInputModel
	{
		[Required]
		public string Name { get; set; }
	}
}
