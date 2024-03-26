using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Staff.AuctionManagement
{
    public class AuctionDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int AuctionId { get; set; }

        public Auction Auction { get; set; }
        public Product Product { get; set; }
        IAuctionService _auctionService { get; set; }
        IProductService _productService { get; set; }

        public AuctionDetailModel(IAuctionService auctionService, IProductService productService)
        {
            _auctionService = auctionService;
            _productService = productService;
        }

        public IActionResult OnGet()
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null || user.Role != 2)
            {
                return RedirectToPage("/Login/Login");
            }

            if (AuctionId <= 0)
            {
                return NotFound();
            }

            Auction = _auctionService.GetAuctionById(AuctionId);
            Product = _productService.getProductById(Auction.Product);
            if (Auction == null || Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
