using System;
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
        public bool Status { get; set; } = false;
        public int? Quantity { get; set; } = 0;
    }
}
