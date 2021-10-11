using System;
using System.Linq;
using Timeline.Data;
using Timeline.Data.Entities;
using Timeline.Repositories.Interfaces;

namespace Timeline.Repositories.Implementations
{
	internal class PersonsRepository : BaseRepository, IPersonsRepository
	{
		public PersonsRepository(TimelineContext context)
			: base(context)
		{

		}

		public IQueryable<Person> All()
		{
			return _context.Persons.AsQueryable();
		}

		public Person GetById(Guid id)
		{
			return _context.Persons.Find(id);
		}

		public Person GetByName(string name)
		{
			return _context.Persons.Where(i => i.Name.Equals(name)).FirstOrDefault();
		}

		public void Add(Person entity)
		{
			_context.Persons.Add(entity);
			_context.SaveChanges();
		}

		public void Update(Person entity)
		{
			_context.Persons.Update(entity);
			_context.SaveChanges();
		}

		public void Remove(Person entity)
		{
			_context.Persons.Remove(entity);
			_context.SaveChanges();
		}
	}
}
