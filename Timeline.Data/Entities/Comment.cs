using System;
using System.Collections.Generic;

namespace Timeline.Data.Entities
{
	public class Comment
	{
		public Guid Id { get; set; }

		public Post Post { get; set; }

		public Person Author { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		public ICollection<Token> Tokens { get; set; }
	}
}
