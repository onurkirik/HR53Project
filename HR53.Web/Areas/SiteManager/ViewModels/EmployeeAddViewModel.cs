using HR53.Repository.Entities;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class EmployeeAddViewModel
    {
        public AppUser User { get; set; }
        public string Password { get; set; }
        public List<Company> Companies { get; set; }
        public IFormFile? PictureUrl { get; set; }
    }
}
