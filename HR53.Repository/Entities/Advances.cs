using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Repository.Entities
{
    public class Advances
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string AdvencesType { get; set; } //düğün,taşınma...
        public DateTime RequestDate { get; set; } //talep tarihi
        public string ApprovalStatus { get; set; } //onay durumu (onay bekliyor, onaylandı,reddedildi,iptal edildi) sadece onay bekleme aşamasında iptal edilebilir.
        public DateTime ReplyDate { get; set; } //cevaplanma tarihi
        public decimal Amount { get; set; } //tutarı (yılda 3 maaş avans kullanılabilir.)




    }
}
