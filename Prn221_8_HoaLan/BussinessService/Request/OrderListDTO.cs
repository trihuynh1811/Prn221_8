using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService.Request
{
    public class OrderListDTO
    {
        public float totalPrice { get; set; }
        public List<CreateOrderDTO> products { get; set; }
    }
}
