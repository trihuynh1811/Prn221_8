using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Products
{

    public class ProductDetailModel : PageModel
    {
        readonly IProductService productService;
        public Product p { get; set; }

        public ProductDetailModel(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult OnGet(int id)
        {
            p = productService.GetById(id);

            return Pages();
        }
    }
}
