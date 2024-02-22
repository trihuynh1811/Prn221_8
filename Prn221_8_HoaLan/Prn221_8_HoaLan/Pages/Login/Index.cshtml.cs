using DataAccessLayer.Models;
using DataAccessLayer.Repository.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
              // Implement logic here
              throw new Exception("Method not implemented");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Page();
            }
        }
    }
}
