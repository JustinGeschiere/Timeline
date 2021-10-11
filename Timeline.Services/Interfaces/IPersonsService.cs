using Timeline.Web.Models.Persons;

namespace Timeline.Services.Interfaces
{
	public interface IPersonsService
	{
		IndexModel GetIndexModel(int currentPage, int pageSize);

		void AddPerson(CreateInputModel model);

		void DeletePerson(DeleteInputModel model);
	}
}
