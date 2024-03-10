using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class ProductDisplayModel : PageModel
    {
        IProductService productService;
        public List<Product> Products;

        public ProductDisplayModel(IProductService iproduct)
        {
            productService = iproduct;
        }
        
        public IActionResult OnGet()
        {
            Products = productService.getAllProduct();
            return Page();
        }
    }
}
