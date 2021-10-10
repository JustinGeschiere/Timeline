using System;
using Timeline.Data.Enums;

namespace Timeline.Data.Entities
{
	public class Token
	{
		public Guid Id { get; set; }

		public string Value { get; set; }

		public TokenType Type { get; set; }
	}
}
