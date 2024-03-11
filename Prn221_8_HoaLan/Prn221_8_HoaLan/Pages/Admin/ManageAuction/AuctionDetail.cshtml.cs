using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Admin.ManageAuction
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
            if (AuctionId <= 0)
            {
                return NotFound();
            }

            Auction = _auctionService.GetAuctionById(AuctionId);
            Product = _productService.getProductById(AuctionId);
            if (Auction == null || Product ==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
