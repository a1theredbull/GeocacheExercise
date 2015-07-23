using Geocaching.Data.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Geocaching.API.Filters
{
    public class UniqueGeocacheNameAttribute : ValidationAttribute
    {
        private const string UniqueNameViolationMessage = "This geocache name is already taken. Please select another.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using(GeocachingContext db = new GeocachingContext())
            {
                if(!db.Geocaches.Any(x => x.Name == value.ToString()))
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
}