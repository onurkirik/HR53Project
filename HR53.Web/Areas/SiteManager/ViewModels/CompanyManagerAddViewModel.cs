using HR53.Repository.Entities;

using System.ComponentModel.DataAnnotations;

namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyManagerAddViewModel
    {
        public AppUser User { get; set; }
        public string Password { get; set; }
        public List<Company> Companies { get; set; }
        [Required(ErrorMessage ="gEREKLİ")]
        public IFormFile PictureUrl { get; set; }
    }
}
