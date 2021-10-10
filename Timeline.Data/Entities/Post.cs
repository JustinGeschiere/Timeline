using System;
using System.Collections.Generic;

namespace Timeline.Data.Entities
{
	public class Post
	{
		public Guid Id { get; set; }

		public Person Author { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		public ICollection<Token> Tokens { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
