using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities.Attributes
{
    public class IdentityCardNoAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Identity number is required.");
            string identityNumber = value.ToString().Trim();
            if (identityNumber.Length != 11)
                return new ValidationResult("Identity number must be 11 digits.");

            if (identityNumber.Any(i => !Char.IsDigit(i)))
                return new ValidationResult("Identity number must only contain digits.");

            if (Convert.ToInt32(identityNumber[0].ToString()) == 0)
                return new ValidationResult("Identity number cannot start with 0.");

            var total = 0; var ciftTotal = 0; var tekTotal = 0;

            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 != 0 && i <= 7)
                    ciftTotal += Convert.ToInt32(identityNumber[i].ToString());
                else if (i % 2 == 0 && i <= 8)
                    tekTotal += Convert.ToInt32(identityNumber[i].ToString());
                total += Convert.ToInt32(identityNumber[i].ToString());
            }

            if ((7 * tekTotal - ciftTotal) % 10 != Convert.ToInt32(identityNumber[9].ToString()))
                return new ValidationResult("Identity number is invalid.");

            if (total % 10 != Convert.ToInt32(identityNumber[10].ToString()))
                return new ValidationResult("Identity number is invalid.");

            return ValidationResult.Success;
        }

    }
}
