using HR53.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities
{
    public class EmployeeAdvance
    {
        public int Id { get; set; }
        public string ? Description { get; set; }
        public TypesForEmployeeAdvanceandExpenditure? Type { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public ConfirmStatusForEmployee ConfirmStatus { get; set; } = ConfirmStatusForEmployee.WaitingForApproval;
        public DateTime ReplyDate { get; set; }
        public int Amount { get; set; }
        public string? Currency { get; set; }
        public bool IsApproved { get; set; } = false;
        public string? CompanyId { get; set; }
        public string? ManagerId { get; set; }
        public int TotalAmount { get; set; } = 0;

        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
