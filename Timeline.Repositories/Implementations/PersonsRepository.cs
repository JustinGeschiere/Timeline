using System;
using System.Collections.Generic;
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

		public IQueryable<Person> Get()
		{
			return _context.Persons.AsQueryable();
		}

		public Person Get(Guid id)
		{
			return _context.Persons.Find(id);
		}

		public void Add(Person entity)
		{
			_context.Persons.Add(entity);
		}

		public void Update(Person entity)
		{
			_context.Persons.Update(entity);
		}

		public void Remove(Person entity)
		{
			_context.Persons.Remove(entity);
		}
	}
}
