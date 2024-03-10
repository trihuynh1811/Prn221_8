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
        public AssignAuctionToStaff(IAuctionService auctionService, IUserService userService)
        {
            _auctionService = auctionService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            Auctions = _auctionService.GetAllAuction();
            Staffs = _userService.GetUserByRoleNameService("Staff");
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
