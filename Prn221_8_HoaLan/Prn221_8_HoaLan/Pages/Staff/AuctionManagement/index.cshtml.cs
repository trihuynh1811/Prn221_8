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

        [BindProperty]
        public string AuctionIda { get; set; }

        public List<string> ProductOwnerName { get; set; } = new List<string>();

        IAuctionService _iAuctionSrv;
        IAuctionDetailService _iAuctionDetailSrv;
        IProductService productService;
        public List<Auction> Auctions;

        public indexModel(IAuctionService auctionService, IAuctionDetailService iAuctionDetailSrv, IProductService productService)
        {
            _iAuctionSrv = auctionService;
            _iAuctionDetailSrv = iAuctionDetailSrv;
            this.productService = productService;
        }

        public IActionResult OnGet()
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
                return RedirectToPage("/Login/Login");
            }
            Auctions = _iAuctionSrv.GetAuctionByHostId(user.UserId);
            if (Auctions != null && Auctions.Count != 0)
            {
                for (int i = 0; i < Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductOwnerName.Add(product.ProductName);
                    }
            }
            return Page();
        }
        public IActionResult OnPost(string button)
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            var AuctionId = int.Parse(AuctionIda);
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
                //_iAuctionSrv.ChangeStatusAuction(AuctionId, "Finshed");
                _iAuctionDetailSrv.EndBidAuction(AuctionId);
                Auctions = _iAuctionSrv.SearchAuctoionByAuctionNameAndStatus(user.UserId, SearchValue, "All");
            }
            if (Auctions != null && Auctions.Count != 0)
            {
                for (int i = 0; i < Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductOwnerName.Add(product.ProductName);
                    }
            }
            return Page();
        }
    }
}
