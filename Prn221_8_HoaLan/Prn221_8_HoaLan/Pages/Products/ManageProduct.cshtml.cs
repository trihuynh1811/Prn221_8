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
            OrderListDTO orderList = new OrderListDTO();

            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
                orderList = JsonConvert.DeserializeObject<OrderListDTO>(requestBody);
            }

            if(orderList.products.Count > 0)
            {
                foreach(CreateOrderDTO product in orderList.products)
                {
                    if(productService.getProductById(product.pId).Quantity <= 0)
                    {
                        return new ContentResult
                        {
                            StatusCode = 406,
                            ContentType = "application/json",
                            Content = JsonConvert.SerializeObject($"product {product.pName} is out of stock, please unselected it from you cart!")
                        };
                    }
                }
                orderService.CreateNewOrder(orderList, user);
            }
            List<CartModel> cart = JsonConvert.DeserializeObject<List<CartModel>>(HttpContext.Session.GetString("Cart"));
            orderList.products.ForEach(x => cart.RemoveAll(y => y.pId.Equals(x.pId.ToString())));
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
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

public class OrderListModel
{
    public string totalPrice { get; set; }
    public List<CreateOrderDTO> products { get; set; }
}

