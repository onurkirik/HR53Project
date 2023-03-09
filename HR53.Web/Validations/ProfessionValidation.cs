using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class ProfessionValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string profession = Convert.ToString(value)!;
            int adet = 0;

            for (int i = 0; i < profession.Length; i++)
            {
                if (profession[i] == ' ')
                {
                    adet++;
                }
            }

            if (adet > 1) return false;

            if (profession.Contains(" ")) return false;
            if (profession.Length == 0) return false;

            if (profession.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
            {
                return false;
            }
            return true;
        }
    }
}

