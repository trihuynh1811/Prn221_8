using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Logout
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            SessionExtensions.Set<User>(HttpContext.Session, "User", null);
            SessionExtensions.Set<string>(HttpContext.Session, "Admin", null);
            return RedirectToPage("/Index");
        }
    }
}
