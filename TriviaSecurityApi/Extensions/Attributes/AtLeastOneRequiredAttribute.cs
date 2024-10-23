using System.ComponentModel.DataAnnotations;

namespace TriviaSecurityApi.Extensions.Attributes
{
    public class AtLeastOneRequiredAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public AtLeastOneRequiredAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);

            if (otherProperty == null)
            {
                return new ValidationResult($"Unknown property: {_otherPropertyName}");
            }

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            if (string.IsNullOrEmpty(value?.ToString()) && string.IsNullOrEmpty(otherValue?.ToString()))
            {
                return new ValidationResult("E-Posta ya da kullanıcı adı girmek zorunludur");
            }

            return ValidationResult.Success;
        }
    }
}
