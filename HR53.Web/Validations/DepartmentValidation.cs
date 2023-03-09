using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class DepartmentValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string department = Convert.ToString(value)!;

            int adet = 0;

            for (int i = 0; i < department.Length; i++)
            {
                if (department[i] == ' ')
                {
                    adet++;
                }
            }

            if (adet > 1) return false;


            string[] kelimeler = department.Trim().Split(" ");

            if (kelimeler.Length == 2)
            {
                if (kelimeler[0].Contains(" ") || kelimeler[0].Any(n => char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
                {
                    return false;

                }

                if (kelimeler[1].Contains(" ") || kelimeler[1].Any(n => char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
                {
                    return false;
                }
            }

            else if (kelimeler.Length == 1)
            {
                if (kelimeler[0].Contains(" ") || kelimeler[0].Any(n => char.IsNumber(n) || char.IsDigit(n) || char.IsPunctuation(n)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
