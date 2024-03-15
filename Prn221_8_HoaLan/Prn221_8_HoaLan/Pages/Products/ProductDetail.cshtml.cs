using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Prn221_8_HoaLan.Pages.Products
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ProductDetailModel : PageModel
    {
        readonly IProductService productService;
        public Product p { get; set; }
        public List<CartModel> cartList = new List<CartModel>();

        public ProductDetailModel(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult OnGet(int id)
        {
            var customer = HttpContext.Session.Get("User");
            if (customer == null)
            {
                return RedirectToPage("../Login/Login");
            }
            p = productService.GetById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCart()
        {
            try
            {
                var serializedCartList = HttpContext.Session.GetString("Cart");
                string requestBody = string.Empty;
                int id;


                using (var reader = new System.IO.StreamReader(Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                    PModel model = JsonConvert.DeserializeObject<PModel>(requestBody);
                    id = model.id;
                }
                Product product = new Product();
                if (id > 0)
                {
                    product = productService.GetById(id);
                    if(product.Quantity <= 0)
                    {
                        return new ContentResult
                        {
                            StatusCode = 400,
                            ContentType = "application/json",
                            Content = JsonConvert.SerializeObject($"{product.ProductName} is out of stock")
                        };
                    }
                }

                CartModel cart = new CartModel
                {
                    pId = product.ProductId.ToString(),
                    pName = product.ProductName,
                    price = product.Price.ToString(),
                    quanity = 1.ToString(),
                    imgLink = product.Image
                };
                if (serializedCartList == null)
                {
                    cartList = new List<CartModel>
                    {
                        cart
                    };
                    serializedCartList = JsonConvert.SerializeObject(cartList);
                    HttpContext.Session.SetString("Cart", serializedCartList);
                }
                else
                {
                    cartList = JsonConvert.DeserializeObject<List<CartModel>>(serializedCartList);
                    var p = cartList.FirstOrDefault(x => x.pId.Equals(id.ToString()));
                    if (p == null)
                    {
                        cartList.Add(cart);
                    }
                    else
                    {
                        p.quanity = (int.Parse(p.quanity) + 1).ToString();
                    }
                    serializedCartList = JsonConvert.SerializeObject(cartList);
                    HttpContext.Session.SetString("Cart", serializedCartList);
                }

                return new ContentResult
                {
                    StatusCode = 200,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject($"lmao {cartList.Count}")
                };


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

    

