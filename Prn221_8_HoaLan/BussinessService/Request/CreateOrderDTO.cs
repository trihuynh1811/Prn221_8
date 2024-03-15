using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Request
{
    public class CreateOrderDTO
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
    }
}
