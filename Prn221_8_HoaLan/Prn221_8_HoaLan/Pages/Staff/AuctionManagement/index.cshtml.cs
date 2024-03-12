using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Staff.AuctionManagement
{
    public class indexModel : PageModel
    {
        [BindProperty]
        public string SearchValue { get; set; }

        [BindProperty]
        public string StatusAuctionValue { get; set; }

        IAuctionService _iAuctionSrv;
        public List<Auction> Auctions;

        public indexModel(IAuctionService auctionService)
        {
            _iAuctionSrv = auctionService;
        }

        public IActionResult OnGet()
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
                return RedirectToPage("/Login/Login");
            }
            Auctions = _iAuctionSrv.GetAuctionByHostId(user.UserId);
            return Page();
        }
        public IActionResult OnPost(string button, int AuctionId)
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
                return RedirectToPage("/Login/Login");
            }
            if ("Search".Equals(button))
            {
                Auctions = _iAuctionSrv.SearchAuctoionByAuctionNameAndStatus(user.UserId, SearchValue, StatusAuctionValue);
            }
            else if("Start Auction".Equals(button))
            {
                _iAuctionSrv.ChangeStatusAuction(AuctionId, "Ongoing");
                Auctions = _iAuctionSrv.SearchAuctoionByAuctionNameAndStatus(user.UserId, SearchValue, "All");
            }
            else if("End Auction".Equals(button))
            {
                _iAuctionSrv.ChangeStatusAuction(AuctionId, "Finshed");
                Auctions = _iAuctionSrv.SearchAuctoionByAuctionNameAndStatus(user.UserId, SearchValue, "All");
            }

            return Page();
        }
    }
}
