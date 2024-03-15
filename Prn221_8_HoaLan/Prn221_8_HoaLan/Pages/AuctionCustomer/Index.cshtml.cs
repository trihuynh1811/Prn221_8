using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionCustomer
{
    public class IndexModel : PageModel
    {
        IAuctionService _iAuctionSrv;
        public List<Auction> Auctions;

        public IndexModel(IAuctionService auctionService)
        {
            _iAuctionSrv = auctionService;
        }
        public IActionResult OnGet()
        {
            Auctions = (List<Auction>)_iAuctionSrv.GetAuctionByStatus("Ongoing");
            return Page();
        }
    }
}
