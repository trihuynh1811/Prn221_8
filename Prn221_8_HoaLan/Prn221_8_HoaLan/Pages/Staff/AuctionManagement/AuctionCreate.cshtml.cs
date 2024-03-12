using BussinessService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Staff.AuctionManagement
{
    public class AuctionCreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int AuctionId { get; set; }

        [BindProperty]
        public float StartPrice { get; set; }

        [BindProperty]
        public float PriceStep { get; set; }

        [BindProperty]
        public DateTime StartTime { get; set; }

        [BindProperty]
        public DateTime EndTime { get; set; }

        IAuctionService auctionService { get; set; }
        public AuctionCreateModel(IAuctionService IAuctionsrv)
        {
            auctionService = IAuctionsrv;
        }

        public IActionResult OnGet(int AuctionId)
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //var StrError = auctionService.checkRegisterAuctionFromStaff(StartPrice, PriceStep, StartTime, EndTime);
            //if (!"No error".Equals(StrError))
            //{
            //    ModelState.AddModelError("Model.EndTime", StrError);
            //    return Page();
            //}
            //auctionService.registerAuctionFromStaff(AuctionId, StartPrice, PriceStep, StartTime, EndTime);
            return RedirectToPage("/Staff/AuctionManagement/index");
        }
    }
}
