using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timeline.Data.Entities
{
	public class Person
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(100)]
		public string EmailAddress { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		public ICollection<Post> Posts { get; set; }

		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";
	}
}
