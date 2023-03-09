using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class PictureValidation : ValidationAttribute
    {
        public int MaxSFileSize { get; set; } = 1;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? photo = value as IFormFile; if (value == null)
                return ValidationResult.Success; if (!photo.ContentType.StartsWith("jpg/"))
            {
                return new ValidationResult("Invalid image file.");
            }
            else if (photo.Length > MaxSFileSize * 1024 * 1024)
            {
                return new ValidationResult($"Maximum size file {MaxSFileSize} MB");
            }
            return ValidationResult.Success;
        }
    }
}
