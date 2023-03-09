using HR53.Web.Areas.SiteManager.Validations;

namespace HR53.Web.Models
{
    public class Company
    {
        public int Id { get; set; }
        [CompanyValidation]
        public string CompanyName { get; set; } = null!;
        
        [CompanyValidation]
        public string Title { get; set; } = null!;

        [CompanyValidation]
        public string MersisNumber { get; set; } = null!; 
        
        [CompanyValidation] 
        public string TaxOffice { get; set; } = null!;
        
        [CompanyValidation]
        public int TaxNumber { get; set; }
        
        [CompanyValidation]
        public string? Logo { get; set; }
        
        [CompanyValidation] 
        public string Phone { get; set; } = null!;
        
        [CompanyValidation] 
        public string Adress { get; set; } = null!;
        
        [CompanyValidation] 
        public string Email { get; set; } = null!;
        
        [CompanyValidation]
        public int TotalEmployeeNumber { get; set; }
        
        [CompanyValidation]
        public DateTime FoundationYear { get; set; }
        
        [CompanyValidation]
        public DateTime ContractStartDate { get; set; }
        
        [CompanyValidation]
        public DateTime ContractFinishDate { get; set; }
        
        [CompanyValidation]
        public bool IsActive { get; set; }
    }
}
