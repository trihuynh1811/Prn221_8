using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class ManageProductModel : PageModel
    {
        readonly IProductService productService;

        public List<Product> productList { get; set; }

        public ManageProductModel(IProductService productService)
        {
            this.productService = productService;
        }

        public void OnGet()
        {

        }
    }
}
