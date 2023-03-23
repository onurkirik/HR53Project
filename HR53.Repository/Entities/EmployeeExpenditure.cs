using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities
{
    public class EmployeeExpenditure
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public DateTime RequestDate { get; set; }
        public string ConfirmStatus { get; set; }
        public DateTime ReplyDate { get; set; }
        public int Amount { get; set; }
        public string? Currency { get; set; }
        public string? FileName { get; set; }
        
        public string? UserId { get; set; }
        public AppUser? User { get; set; }

    }
}
