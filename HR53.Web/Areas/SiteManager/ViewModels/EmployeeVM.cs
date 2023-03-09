namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class EmployeeVM
    {
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? PhotoUrl { get; set; }
    }
}
