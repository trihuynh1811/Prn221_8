using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class ManageProductModel : PageModel
    {
        readonly IProductService productService;

        public List<Product> productList { get; set; }
        public List<CartModel> cartList = new List<CartModel>();

        public ManageProductModel(IProductService productService)
        {
            this.productService = productService;
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

