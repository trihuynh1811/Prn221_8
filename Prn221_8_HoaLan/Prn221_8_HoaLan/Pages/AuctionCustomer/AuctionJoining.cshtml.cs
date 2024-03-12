using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionCustomer
{
    public class AuctionJoiningModel : PageModel
    {
        IAuctionService auctionService;
        IAuctionDetailService auctionDetailService;
        IProductService productService;

        public Auction auction;
        public Product product;
        public List<AuctionDetail> AuctionDetails { get; set; }
        [BindProperty]
        public float BidPrice { get; set; }
        public float CurrentPrice { get; set; }

        public AuctionJoiningModel(IAuctionService iauctionsrv, IAuctionDetailService iauctiondetail, IProductService iproductsrv)
        {
            auctionService = iauctionsrv;
            auctionDetailService = iauctiondetail;
            productService = iproductsrv;
        }


        public IActionResult OnGet(int AuctionId)
        {
            //var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            //if (user == null)
            //{
            //    return Redirect("../Login/Login");
            //}
            auction = auctionService.GetAuctionById(AuctionId);
            if (auction == null)
            {
                return Redirect("./NoAuthoriztion");
            }
            product = productService.getProductById(auction.Product);
            if (product == null)
            {
                return Redirect("./NoAuthoriztion");
            }
            AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
            CurrentPrice = auctionDetailService.GetCurrentPriceSrv(AuctionId);
            ModelState.Clear();
            return Page();
        }


        public IActionResult OnPost(int AuctionId)
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            //if (user == null)
            //{
            //    return Redirect("../Login/Login");
            //}
            auction = auctionService.GetAuctionById(AuctionId);
            if (auction == null)
            {
                return Redirect("./NoAuthoriztion");
            }
            product = productService.getProductById(auction.Product);
            if (product == null)
            {
                return Redirect("./NoAuthoriztion");
            }
            
            CurrentPrice = auctionDetailService.GetCurrentPriceSrv(AuctionId);
            var StrError = auctionDetailService.CheckBidPrice(BidPrice, CurrentPrice, (float)auction.PriceStep);
            if (!"No Error".Equals(StrError))
            {
                ModelState.AddModelError("Model.EndTime", StrError);
                AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
                return Page();
            }
            auctionDetailService.InsertBidToAuctionDetail(user.UserId, auction.AuctionId, BidPrice, DateTime.Now);
            AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
            CurrentPrice = BidPrice;
            return Page();
        }
    }
}
