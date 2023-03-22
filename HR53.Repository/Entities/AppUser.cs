
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
      
        public string? IdentityCardNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        [MaxLength(10, ErrorMessage = "!0 dan uzun olamaz")]
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Picture { get; set; }
        public override string? UserName { get; set; }
        public int LoginCount { get; set; } = 0;

        public string? CompanyIdString { get; set; }
        public Company? Company { get; set; }

        public List<EmployeeAdvance>? EmployeeAdvances { get; set; }
        public List<EmployeeExpenditure>? EmployeeExpenditures { get; set; }
    }
}
