using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool Status { get; set; }
        public int? OrderBy { get; set; }
        public bool? IsAuction { get; set; }

        public virtual User? OrderByNavigation { get; set; }
        public virtual Auction? Auction { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
