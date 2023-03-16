using HR53.Repository.Entities.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HR53.Repository.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Birthplace { get; set; }

        [IdentityCardNoValidation(ErrorMessage = "The Identity No is Invalid")]
        public string? IdentityCardNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Picture { get; set; }
        public override string? UserName { get; set; }
        private string? _companyEmail { get; set; }
        public string? CompanyEmail
        {
            get
            {
                if (Firstname == null || LastName == null) return null; // Firstname veya LastName null ise null döndürün
                return Firstname.ToLower() + "." + LastName.ToLower() + "@bilgeadam.com";

            }
            set { _companyEmail = value; }
        }


        public string? CompanyIdString { get; set; }
        public Company Company { get; set; }

    }
}
