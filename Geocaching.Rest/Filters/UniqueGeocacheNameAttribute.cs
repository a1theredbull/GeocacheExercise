using Geocaching.Data.Repository.Implementation;
using Geocaching.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geocaching.Rest.Filters
{
    public class UniqueGeocacheNameAttribute : ValidationAttribute
    {
        private const string UniqueNameViolationMessage = "This geocache name is already taken. Please select another.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repo = DependencyResolver.Current.GetService<IGeocacheRepository>();
            if (repo.IsUniqueName(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(UniqueNameViolationMessage);
            }
        }
    }
}