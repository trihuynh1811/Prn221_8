using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages
{
    public class IndexModel : PageModel
    {
        public IProductService ProductService;
        public List<Product> Products;
        public IndexModel(IProductService iPro)
        {
            ProductService = iPro;
        }

        public IActionResult OnGet()
        {
            Products = ProductService.GetProductsNotInAuctionAndInStock();
            return Page();
        }
    }
}