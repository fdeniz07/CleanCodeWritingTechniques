using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithMethods
{
    public static class Utility
    {
        /// <summary>
        /// Validates the object using validator
        /// </summary>
        /// <param name="validator">Validator implemented from IValidator.</param>
        /// <param name="entity">Verified entity</param>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException"></exception>
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
