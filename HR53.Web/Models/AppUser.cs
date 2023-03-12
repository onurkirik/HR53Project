using Microsoft.AspNetCore.Identity;

namespace HR53.Web.Models
{
    public class AppUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Birthplace { get; set; }
        public string? IdentityCardNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Picture { get; set; }


        public string? CompanyIdString { get; set; }
        public Company Company { get; set; }

    }
}
