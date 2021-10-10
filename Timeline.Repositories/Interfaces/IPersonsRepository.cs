using System;
using System.Linq;
using Timeline.Data.Entities;

namespace Timeline.Repositories.Interfaces
{
	public interface IPersonsRepository
	{
		IQueryable<Person> Get();
		Person Get(Guid id);
		void Add(Person entity);
		void Update(Person entity);
		void Remove(Person entity);
	}
}
