﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Timeline.Vertical.Features.Helpers
{
	public static class ValidationHelper
	{
		public static IEnumerable<Exception> ValidateAnnotations<T>(T command, bool validateAllProperties = true)
		{
			var context = new ValidationContext(command);

			var results = new List<ValidationResult>();

			if (Validator.TryValidateObject(command, context, results, validateAllProperties))
			{
				return Enumerable.Empty<Exception>();
			}

			return results.Select(i => new ValidationException(i.ErrorMessage));
		}
	}
}
