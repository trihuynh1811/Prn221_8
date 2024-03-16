using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Orders
{
    public class OrderDetailModel : PageModel
    {
        readonly IOrderService orderService;
        public List<OrderDetail> orderDetails { get; set; }

        public OrderDetailModel(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public IActionResult OnGet(int id)
        {
            orderDetails = orderService.GetAllOrderDetailByOrderId(id);
            return Page();
        }
    }
}
