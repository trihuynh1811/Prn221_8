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
        public string AuctionName { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public int? OrderId { get; set; }
        public int? Product { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product ProductNavigation { get; set; }
        public virtual ICollection<AuctionDetail> AuctionDetails { get; set; }
    }
}
