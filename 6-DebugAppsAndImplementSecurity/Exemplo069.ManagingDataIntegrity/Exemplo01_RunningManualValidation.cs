using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exemplo069.ManagingDataIntegrity
{
    public static class Exemplo01_RunningManualValidation
    {
    }

    public static class GenericValidator<T>
    {
        public static IList<ValidationResult> Validate(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, results);
            return results;
        }
    }
}
