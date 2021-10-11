using System;
using System.Linq;
using Timeline.Data.Entities;

namespace Timeline.Repositories.Interfaces
{
	public interface IPersonsRepository
	{
		IQueryable<Person> All();
		Person GetById(Guid id);
		Person GetByName(string name);
		void Add(Person entity);
		void Update(Person entity);
		void Remove(Person entity);
	}
}
