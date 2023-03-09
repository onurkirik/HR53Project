using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class SurnameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string Surname = Convert.ToString(value)!;

            if (Surname.Contains(" ")) return false;
            if (Surname.Length == 0) return false;

            if (Surname.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }
            return true;
        }
    }
}