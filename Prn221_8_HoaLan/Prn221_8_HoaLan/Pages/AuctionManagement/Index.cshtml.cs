using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionManagement
{
    public class IndexModel : PageModel
    {
        IAuctionService _iAuctionSrv;
        IProductService productService;
        public List<Auction> Auctions = new List<Auction>();
        public List<String> ProductName = new List<string>();
        public List<string> StaffManageName = new List<string>();
        public IndexModel(IAuctionService auctionService, IProductService productService)
        {
            _iAuctionSrv = auctionService;
            this.productService = productService;
        }
        public IActionResult OnGet()
        {
            var user = Prn221_8_HoaLan.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
                return RedirectToPage("/Login/Login");
            }
            if (user.Role == 4)
            {
                Auctions = (List<Auction>)_iAuctionSrv.GetAuctionByStatus("Ongoing");
                StaffManageName = _iAuctionSrv.getStaffsInAuction(Auctions);
            }
            else if (user.Role == 3)
            {
                Auctions = (List<Auction>)_iAuctionSrv.GetAuctionByProductOwnerId(user.UserId);
                StaffManageName = _iAuctionSrv.getStaffsInAuction(Auctions);
            }
            ProductName = new List<String>();
            if(Auctions!=null && Auctions.Count != 0)
            {
                for(int i=0; i<Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductName.Add(product.ProductName);
                    }
            }
            return Page();
        }
    }
}
