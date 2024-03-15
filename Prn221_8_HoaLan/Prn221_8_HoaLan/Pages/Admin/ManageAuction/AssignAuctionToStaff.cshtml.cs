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
        public List<User> Staffs;

        [BindProperty]
        public int SelectedStaffId {  get; set; }

        [BindProperty(Name = "AuctionId")]
        public int AuctionId { get; set; }

        public AssignAuctionToStaff(IAuctionService auctionService, IUserService userService)
        {
            _auctionService = auctionService;
            _userService = userService;
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

            return Page();
        }
    }
}
