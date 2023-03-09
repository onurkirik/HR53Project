using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Validations
{
    public class EmploymentDateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;

                if (dateTime > DateTime.Now) return false;

                return true;

            }
            return false;
        }
    }
}