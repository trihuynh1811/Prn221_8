using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class AuctionDetail
    {
        public int AuctionDetailId { get; set; }
        public int AuctionId { get; set; }
        public int? ParticipantId { get; set; }
        public double ParticipantPrice { get; set; }
        public DateTime BidTime { get; set; }

        public virtual Auction Auction { get; set; } = null!;
        public virtual User? Participant { get; set; }
    }
}
