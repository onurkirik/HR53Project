using HR53.Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerAddViewModel
    {
        //public int Id { get; set; }
        public string UserName { get; set; } = "CompanyManager";

        public string Firstname { get; set; }

        public string? Middlename { get; set; }

        public string Surname { get; set; }

        public string? SecondSurname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Birthplace { get; set; }

        public string IdentityCardNo { get; set; }

        public DateTime EmploymentDate { get; set; }

        public string Profession { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }
        public string? Password { get; set; }

        public IFormFile? PhotoUrl { get; set; }
    }
}
