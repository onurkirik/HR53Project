using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class BirthDateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;

                if (dateTime > DateTime.Now) return false;

                if (dateTime.Year < 1920) return false;

                return true;

            }
            return false;
        }
    }
}
