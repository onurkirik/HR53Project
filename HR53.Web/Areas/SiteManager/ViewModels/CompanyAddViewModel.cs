namespace HR53.Web.Areas.SiteManager.ViewModels
{
    public class CompanyAddViewModel
    {

        public string CompanyName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string MersisNumber { get; set; } = null!;
        public string TaxOffice { get; set; } = null!;
        public int TaxNumber { get; set; }
        public IFormFile Logo { get; set; }
        public string Phone { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int TotalEmployeeNumber { get; set; }
        public DateTime FoundationYear { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public bool IsActive { get; set; }
    }
}
