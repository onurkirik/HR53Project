using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class BirthPlaceValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string birthPlace = Convert.ToString(value)!;

            if (birthPlace.Contains(" ")) return false;
            if (birthPlace.Length == 0) return false;

            if (birthPlace.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }
            return true;
        }
    }
}
