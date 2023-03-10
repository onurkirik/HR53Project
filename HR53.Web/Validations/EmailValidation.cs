using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class EmailValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false; string gelenDeger = value.ToString().Trim(); if (gelenDeger.Split("@").Length != 2 || gelenDeger.Contains(" "))
                return false;
            if (gelenDeger.EndsWith("@bilgeadam.com") || gelenDeger.EndsWith("@bilgeadamboost.com"))
                return true;
            return base.IsValid(value);
        }
    }
}

