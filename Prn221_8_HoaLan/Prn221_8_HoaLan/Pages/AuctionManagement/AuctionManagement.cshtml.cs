using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionManagement
{

    public class AuctionManagementModel : PageModel
    {
        private readonly IProductService productService;

        public AuctionManagementModel(IProductService productService)
        {
            this.productService = productService;
        }

        [BindProperty]
        public List<Product> Products { get; set; }

        public IActionResult OnGet()
        {
            // Mock data
            Products = productService.GetProducts();

            return Page();
        }

        public IActionResult OnPostApproveDecline(int id, string status)
        {
            productService.SetProductStatus(id, status);
        }
    }
}
