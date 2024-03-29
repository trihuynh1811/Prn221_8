﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Request
{
    public class CreateUpdateProductDTO
    {
        public string? Description { get; set; }
        public string? Image { get; set; }
        public float Price { get; set; }
        public string? ProductName { get; set; }
        public string Status { get; set; } = "processing";
        public int? Quantity { get; set; } = 0;
        public int UserId { get; set; }
        public int? IsAuction { get; set; } = 0;
    }
}
