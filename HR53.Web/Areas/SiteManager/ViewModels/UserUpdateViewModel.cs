namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class UserUpdateViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Profession { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Picture { get; set; }
    }
}
