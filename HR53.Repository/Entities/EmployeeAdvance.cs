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
        public TypesForEmployeeAdvanceandExpenditure type { get; set; }
        public DateTime RequestDate { get; set; }
        public ConfirmStatusForEmployee ConfirmStatus { get; set; }
        public DateTime ReplyDate { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
