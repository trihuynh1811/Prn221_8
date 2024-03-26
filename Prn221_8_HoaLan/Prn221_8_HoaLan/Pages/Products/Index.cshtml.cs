using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Model;
using BussinessService;
using Newtonsoft.Json;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class IndexModel : PageModel
    {
        IProductService productService;
        public Paging<Product> Products;
        public IndexModel(IProductService iproduct)
        {
            productService = iproduct;
        }

        public IActionResult OnGetAsync(int? pageIndex)
        {
            var customer = HttpContext.Session.GetString("User");
            if (customer == null)
            {
                return RedirectToPage("../Login/Login");
            }
            User user = JsonConvert.DeserializeObject<User>(customer);
            IQueryable<Product>? result = null;
            result = productService.GetProductsUsingContextByUserId(user.UserId);

            Products = Paging<Product>.CreateAsync(
                result, pageIndex ?? 1, 5).Result;
            return Page();
        }
    }
}
