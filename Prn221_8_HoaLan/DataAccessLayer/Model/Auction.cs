using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class Auction
    {
        public Auction()
        {
            AuctionDetails = new HashSet<AuctionDetail>();
        }

        public int AuctionId { get; set; }
        public string? AuctionName { get; set; }
        public string Status { get; set; } = null!;
        public int? OrderId { get; set; }
        public int? Product { get; set; }
        public int? CreateBy { get; set; }
        public int? HostBy { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public float? PriceStep { get; set; }
        public float? StartPrice { get; set; }
        public int? WinnerId { get; set; }
        public float? EndPrice { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? ProductNavigation { get; set; }
        public virtual ICollection<AuctionDetail> AuctionDetails { get; set; }
    }
}
