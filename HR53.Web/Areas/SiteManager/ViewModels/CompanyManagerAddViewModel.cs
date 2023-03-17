using HR53.Repository.Entities;
using HR53.Repository.Entities.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerAddViewModel
    {
        public AppUser User { get; set; }
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Birthplace { get; set; }

        [IdentityCardNo]
        public string? IdentityCardNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        [MaxLength(10, ErrorMessage = "!0 dan uzun olamaz")]
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Picture { get; set; }
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


        public string Password { get; set; }
        public List<Company> Companies { get; set; }
        [Required(ErrorMessage ="gEREKLİ")]
        public IFormFile PictureUrl { get; set; }
    }
}
