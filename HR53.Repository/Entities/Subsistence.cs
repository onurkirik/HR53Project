using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities
{
    public class Subsistence
    {
        public int Id { get; set; }
        public string SubsistenceType { get; set; } = null!;// seyahat,konaklama,yeme-içme,uçak vb.
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; } //talep tarihi
        public string? ApprovalStatus { get; set; } //onay durumu (onay bekliyor, onaylandı,reddedildi,iptal edildi) sadece onay bekleme aşamasında iptal edilebilir.
        public DateTime ReplyDate { get; set; } //cevaplanma tarihi
        public string SubsistenceFile { get; set; } = null!;
    }
}
