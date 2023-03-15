using Microsoft.AspNetCore.Identity;

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
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Picture { get; set; }
        [ProtectedPersonalData]
        public override string Email { get; set; }

        public string DisplayEmail
        {
            get
            {
                if (Firstname == null || LastName == null) return null; // Firstname veya LastName null ise null döndürün
                var emailName = Email?.Split('@')[0] ?? ""; // Email özelliği null ise boş bir string döndürün
                return Firstname.ToLower() + "." + LastName.ToLower() + "@bilgeadam.com";

            }
            set { Email = value; }
        }


        public string? CompanyIdString { get; set; }
        public Company Company { get; set; }

    }
}
