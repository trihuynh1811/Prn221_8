using BussinessService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Model;
using Newtonsoft.Json;

namespace Prn221_8_HoaLan.Pages.Orders
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ManageOrderModel : PageModel
    {
        readonly IOrderService orderService;
        public List<Order> orderList = new List<Order>();

        public ManageOrderModel(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult OnGet()
        {
            var customer = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (customer == null)
            {
                return RedirectToPage("../Login/Login");
            }
            orderList = orderService.GetOrdersByUser(customer);
            return Page();
        }
    }
}
