using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Model;
using Repository;
using BussinessService;


namespace Prn221_8_HoaLan.Pages.Admin.ManageAuction
{
    public class AssignAuctionToStaff : PageModel
    {
        public List<Auction> Auctions;
        IAuctionService _auctionService;
        IUserService _userService;
        IProductService productService;
        public List<User> Staffs;

        [BindProperty]
        public int SelectedStaffId {  get; set; }

        [BindProperty(Name = "AuctionId")]
        public int AuctionId { get; set; }

        public List<string> ProductName { get; set; } = new List<string>();
        public List<string> ProductOwnerName { get; set; } = new List<string>();


        public AssignAuctionToStaff(IAuctionService auctionService, IUserService userService, IProductService productService)
        {
            _auctionService = auctionService;
            _userService = userService;
            this.productService = productService;
        }

        public IActionResult OnGet()
        {
            var admin = Prn221_8_HoaLan.SessionExtensions.Get<String>(HttpContext.Session, "Admin");
            if (admin == null)
            {
                return RedirectToPage("/NoAuthorization");
            }
            Auctions = _auctionService.GetAllAssignedAuction();
            Staffs = _userService.GetActiveStaffSrv();
            if (Auctions != null && Auctions.Count != 0)
            {
                for (int i = 0; i < Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductName.Add(product.ProductName);
                    }
            }
            ProductOwnerName = _auctionService.getProductOnersNameInAuction(Auctions);
            return Page();
        }

        public IActionResult OnPost()
        {
            var admin = Prn221_8_HoaLan.SessionExtensions.Get<String>(HttpContext.Session, "Admin");
            if (admin == null)
            {
                return RedirectToPage("/NoAuthorization");
            }
            if (SelectedStaffId != null)
            {
                _auctionService.AssignToStaff(SelectedStaffId, AuctionId);
            }
            Auctions = _auctionService.GetAllAssignedAuction();
            Staffs = _userService.GetUserByRoleNameService("Staff");
            if (Auctions != null && Auctions.Count != 0)
            {
                for (int i = 0; i < Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductName.Add(product.ProductName);
                    }
            }
            ProductOwnerName = _auctionService.getProductOnersNameInAuction(Auctions);
            return Page();
        }
    }
}
