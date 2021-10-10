using System;
using System.Collections.Generic;

namespace Timeline.Data.Entities
{
	public class Person
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public ICollection<Post> Posts { get; set; }
	}
}
