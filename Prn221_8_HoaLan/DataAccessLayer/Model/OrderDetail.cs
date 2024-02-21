using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int? Orders { get; set; }
        public int? Product { get; set; }

        public virtual Order OrdersNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
