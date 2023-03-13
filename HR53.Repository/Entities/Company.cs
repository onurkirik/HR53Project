
namespace HR53.Repository.Entities
{
    public class Company
    {
        public string Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string MersisNumber { get; set; } = null!;

        public string TaxOffice { get; set; } = null!;

        public int TaxNumber { get; set; }

        public string? Logo { get; set; }

        public string Phone { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int TotalEmployeeNumber { get; set; }

        public DateTime FoundationYear { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractFinishDate { get; set; }

        public bool IsActive { get; set; }

        public string? UserId { get; set; }
        public AppUser User { get; set; }
    }
}
