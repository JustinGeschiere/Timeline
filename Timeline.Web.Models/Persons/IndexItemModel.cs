using System;
using Timeline.Data.Entities;

namespace Timeline.Web.Models.Persons
{
	public struct IndexItemModel
	{
		public IndexItemModel(Person entity)
		{
			Id = entity.Id;
			Name = entity.Name;
		}

		public Guid Id { get; }

		public string Name { get; }
	}
}
