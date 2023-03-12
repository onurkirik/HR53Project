using HR53.Web.Validations;
using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerAddViewModel
    {
        //public int Id { get; set; }
        public string UserName { get; set; } = "CompanyManager";

        [FirstNameValidation(ErrorMessage = "Invalid first name")]
        public string Firstname { get; set; }

        [MiddleNameValidation(ErrorMessage = "Invalid middlename")]
        public string? Middlename { get; set; }

        [SurnameValidation(ErrorMessage = "Invalid surname")]
        public string Surname { get; set; }

        [SecondSurnameValidation(ErrorMessage = "Invalid second surname")]
        public string? SecondSurname { get; set; }

        [BirthDateValidation(ErrorMessage = "Invalid birth date.")]
        public DateTime Birthdate { get; set; }

        [BirthPlaceValidation(ErrorMessage = "Invalid birth place")]
        public string Birthplace { get; set; }

        [IdentityCardNoValidation(ErrorMessage = "Invalid identity card no")]
        public string IdentityCardNo { get; set; }

        [EmploymentDateValidation(ErrorMessage = "Invalid employment date")]
        public DateTime EmploymentDate { get; set; }

        [ProfessionValidation(ErrorMessage = "Invalid profession")]
        public string Profession { get; set; }

        [DepartmentValidation(ErrorMessage = "Invalid department name")]
        public string Department { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }

        [PictureValidation(ErrorMessage = "Invalid image")]
        public IFormFile? PhotoUrl { get; set; }
    }
}
