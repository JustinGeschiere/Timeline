using System;
using System.Collections.Generic;

namespace Timeline.Data.Entities
{
	public class Person
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		public ICollection<Post> Posts { get; set; }
	}
}
