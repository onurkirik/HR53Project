using HR53.Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerAddViewModel
    {
        public AppUser User { get; set; }
        public List<Company> Companies { get; set; }
        public IFormFile PictureUrl { get; set; }
    }
}
