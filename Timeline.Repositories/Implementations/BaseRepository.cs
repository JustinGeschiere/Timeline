using Timeline.Data;

namespace Timeline.Repositories.Implementations
{
	internal class BaseRepository
	{
		private protected readonly TimelineContext _context;

		public BaseRepository(TimelineContext context)
		{
			_context = context;
		}
	}
}
