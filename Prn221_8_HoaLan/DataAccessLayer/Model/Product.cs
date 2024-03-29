﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class Product
    {
        public Product()
        {
            Auctions = new HashSet<Auction>();
            OrderDetails = new HashSet<OrderDetail>();
            Reports = new HashSet<Report>();
        }

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public string? ProductName { get; set; }
        public string Status { get; set; } = null!;
        public int? Quantity { get; set; }
        public bool IsAuction { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
