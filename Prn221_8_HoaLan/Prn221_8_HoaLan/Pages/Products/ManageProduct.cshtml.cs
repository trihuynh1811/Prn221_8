using BussinessService;
using BussinessService.Request;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Prn221_8_HoaLan.Pages.Orders;
using System.Collections.Generic;

namespace Prn221_8_HoaLan.Pages.Products
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ManageProductModel : PageModel
    {
        readonly IProductService productService;
        readonly IOrderService orderService;

        public List<Product> productList { get; set; }
        public List<CartModel> cartList = new List<CartModel>();

        public ManageProductModel(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;   
        }

        public IActionResult OnGet()
        {
            var serializedCartList = HttpContext.Session.GetString("Cart");
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");

            if(user == null)
            {
                return RedirectToPage("../Login/Login");
            }

            if (serializedCartList != null)
            {
                cartList = JsonConvert.DeserializeObject<List<CartModel>>(serializedCartList);

            }
            return null;
        }

        public async Task<IActionResult> OnPostAddToOrder()
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");

            if (user == null)
            {
                return RedirectToPage("../Login/Login");
            }

            string requestBody = string.Empty;
            List<CreateOrderDTO> orderList = new List<CreateOrderDTO>();

            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
                orderList = JsonConvert.DeserializeObject<List<CreateOrderDTO>>(requestBody);
            }

            if(orderList.Count > 0)
            {
                orderService.CreateNewOrder(orderList, user);
            }

            return new ContentResult
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject("lmao")
            };
        }
    }
}

public class CartModel
{
    public string pId { get; set; }
    public string pName { get; set; }
    public string imgLink { get; set; }
    public string price { get; set; }
    public string quanity { get; set; }
}

