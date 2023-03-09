using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class FirstNameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string firstName = Convert.ToString(value)!;

            if (firstName.Contains(" ")) return false;

            if (firstName.Length == 0) return false;

            if (firstName.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }

            return true;
        }
    }
}
