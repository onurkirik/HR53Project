using HR53.Repository.Entities;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerUpdateViewModel
    {
        public AppUser User { get; set; }
        public List<Company> Companies { get; set; }
    }
}
