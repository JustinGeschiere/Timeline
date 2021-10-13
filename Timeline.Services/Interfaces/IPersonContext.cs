using Timeline.Data.Entities;

namespace Timeline.Services.Interfaces
{
	public interface IPersonContext
	{
		public const string COOKIE_KEY = "dibsed-person";
		public const string CLAIM_KEY = "dibsed-person";

		public Person CurrentPerson { get; }
	}
}
