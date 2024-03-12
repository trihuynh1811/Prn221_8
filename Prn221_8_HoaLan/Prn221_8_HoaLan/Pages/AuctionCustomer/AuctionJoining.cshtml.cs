using BussinessService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionCustomer
{
    public class AuctionJoiningModel : PageModel
    {
        IAuctionService auctionService;
        //IAuctionDetailService
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
