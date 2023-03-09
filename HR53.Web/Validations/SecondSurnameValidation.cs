using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class SecondSurnameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            string secondSurname = Convert.ToString(value)!;

            if (secondSurname.Contains(" ")) return false;
            if (secondSurname.Length == 0) return false;

            if (secondSurname.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }
            return true;
        }
    }
}
