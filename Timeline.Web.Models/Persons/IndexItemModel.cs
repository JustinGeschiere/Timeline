using System;
using Timeline.Data.Entities;

namespace Timeline.Web.Models.Persons
{
	public class IndexItemModel
	{
		public IndexItemModel(Person entity)
		{
			Id = entity.Id;
			Name = entity.FirstName;
			Created = entity.Created.ToLocalTime().ToLongDateString();
			Modified = entity.Created.Equals(entity.Modified) ? "-" : entity.Modified.ToLocalTime().ToLongDateString();
		}

		public Guid Id { get; }

		public string Name { get; }

		public string Created { get; }

		public string Modified { get; }
	}
}
