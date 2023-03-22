using HR53.Repository.Entities;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class UpdateEmployeeViewModel
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }

        public IFormFile? PictureUrl { get; set; }
    }
}
