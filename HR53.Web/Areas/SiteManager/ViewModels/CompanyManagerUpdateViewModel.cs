using HR53.Web.Models;
using HR53.Web.Validations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerUpdateViewModel
    {
        public AppUser User { get; set; }
        public List<Company> Companies { get; set; }
    }
}
