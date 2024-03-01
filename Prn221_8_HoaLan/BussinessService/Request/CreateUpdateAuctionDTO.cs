using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Request
{
    public class CreateUpdateAuctionDTO
    {
        public string? AuctionName { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; } = false;
        public int? Product { get; set; }
        public int? Quantity { get; set; }
    }
}
