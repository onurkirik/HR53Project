using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class PhoneNumberValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string phoneNumber = Convert.ToString(value)!;

            char[] numbers = phoneNumber.ToCharArray();

            bool x = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!Char.IsNumber(numbers[i]))
                {
                    x = false;
                    break;
                }

            }
            if (x == false) return false;

            if (phoneNumber.Length == 11)
            {
                if (Convert.ToInt32(numbers[0]) == 48)
                {
                    return true;
                }
            }

            if (phoneNumber.Any(n => Char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n))) return false;
            return true;
        }
    }
}
