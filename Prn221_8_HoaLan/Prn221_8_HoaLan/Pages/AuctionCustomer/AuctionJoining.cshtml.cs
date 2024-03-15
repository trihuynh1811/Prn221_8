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
        public String Host;
        public String CreateBy;
        public List<String> listParticipant;
        public List<AuctionDetail> AuctionDetails { get; set; }
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

            Host = auctionService.GetNameByAuctionId(AuctionId, (int)auction.HostBy);
            CreateBy = auctionService.GetNameByAuctionId(AuctionId, (int)auction.CreateBy);
            listParticipant = auctionDetailService.GetListUserNameInAuctionDetail(AuctionId);
            AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
            CurrentPrice = auctionDetailService.GetCurrentPriceSrv(AuctionId);
            ModelState.Clear();
            if (auction.EndTime < DateTime.Now)
            {
                ViewData["EndBibMessage"] = "THE AUCTION IS ENDED!";
            }
            else
            {
                ViewData["EndBibMessage"] = "";
            }
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
            // Get Host and product owner and customer name
            Host = auctionService.GetNameByAuctionId(AuctionId, (int)auction.HostBy);
            CreateBy = auctionService.GetNameByAuctionId(AuctionId, (int)auction.CreateBy);
            listParticipant = auctionDetailService.GetListUserNameInAuctionDetail(AuctionId);

            CurrentPrice = auctionDetailService.GetCurrentPriceSrv(AuctionId);
            AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
            // Kiem tra con thoi gian khong?
            DateTime currentTime = DateTime.Now;
            if (auction.EndTime < currentTime)
            {
                ViewData["EndBibMessage"] = "THE AUCTION IS ENDED!";
                return Page();
            }
            var StrError = auctionDetailService.CheckBidPrice(BidPrice, CurrentPrice, (float)auction.PriceStep);
            if (!"No Error".Equals(StrError))
            {
                ModelState.AddModelError("Model.EndTime", StrError);
                AuctionDetails = auctionDetailService.GetAllAuctionDetailByAuctionId(AuctionId);
                return Page();
            }
            auctionDetailService.InsertBidToAuctionDetail(user.UserId, auction.AuctionId, BidPrice, DateTime.Now);
            
            CurrentPrice = BidPrice;
            return Page();
        }
    }
}
