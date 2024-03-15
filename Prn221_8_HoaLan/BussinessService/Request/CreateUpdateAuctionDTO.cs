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
        public string Status { get; set; } = "Processing";
        public int? Product { get; set; }
        public int CreateBy { get; set; }
    }
}
