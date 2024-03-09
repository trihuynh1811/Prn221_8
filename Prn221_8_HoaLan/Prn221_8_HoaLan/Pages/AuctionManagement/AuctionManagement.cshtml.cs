using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace Prn221_8_HoaLan.Pages.AuctionManagement
{

    public class AuctionManagementModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }

        IProductRepository _iproduct;
        public AuctionManagementModel(IProductRepository iProduct)
        {
            _iproduct = iProduct;
        }
        public IActionResult OnGet()
        {
            Products = _iproduct.GetAll();
            return Page();
        }
    }
}
