using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class AuctionDetail
    {
        public int AuctionDetailId { get; set; }
        public int HostId { get; set; }
        public int WinnerId { get; set; }
        public int? Auction { get; set; }
        public int? Participant { get; set; }

        public virtual Auction? AuctionNavigation { get; set; }
        public virtual User? ParticipantNavigation { get; set; }
    }
}
