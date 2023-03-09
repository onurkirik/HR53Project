using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class MiddleNameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {

            if (value == null) return true;

            string middlename = Convert.ToString(value)!;

            if (middlename.Contains(" ")) return false;

            if (middlename.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }
            return true;
        }
    }
}
