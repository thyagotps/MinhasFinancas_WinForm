using System.ComponentModel.DataAnnotations;

namespace Controller
{
    public static class ValidationDtos
    {
        public static IEnumerable<ValidationResult> GetValidationErrorResults(object obj)
        {
            var listaErrors = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, listaErrors, true);
            return listaErrors;
        }
    }
}
