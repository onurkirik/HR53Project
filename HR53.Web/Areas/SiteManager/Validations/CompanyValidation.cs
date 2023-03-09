using HR53.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.Validations
{
    public class CompanyValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var company = value as Company; if (company == null) { return new ValidationResult("Invalid model type."); }
            if (string.IsNullOrEmpty(company.CompanyName)) { return new ValidationResult("Şirket adı boş geçilemez"); }
            if (string.IsNullOrEmpty(company.Phone)) { return new ValidationResult("Şirket telefonu boş geçilemez"); }
            if (string.IsNullOrEmpty(company.Email)) { return new ValidationResult("Şirket maili boş geçilemez"); }
            if (string.IsNullOrEmpty(company.TaxNumber.ToString())) { return new ValidationResult("Şirket vergi numarası boş geçilemez"); }
            if (string.IsNullOrEmpty(company.Adress)) { return new ValidationResult("Şirket adresi boş geçilemez"); }
            if (string.IsNullOrEmpty(company.Title)) { return new ValidationResult("Şirket tanımı boş geçilemez"); }
            if (company.Phone.Length == 10 && company.Phone[0] != '0') { return ValidationResult.Success; }
            return new ValidationResult("Şirket telefon numarasını başında 0 olmadan ve 10 karakter giriniz.");
        }
    }
}
