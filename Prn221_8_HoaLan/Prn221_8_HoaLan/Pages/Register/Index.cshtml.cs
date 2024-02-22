using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.Register
{
  public class RegisterModel : PageModel
  {
      [BindProperty]
      public User User { get; set; }

      [BindProperty]
      public string ConfirmPassword { get; set; }

      public void OnGet()
      {
      }

      public async Task<IActionResult> OnPostAsync()
      {
        // Implement logic here
        throw new Exception("method not implemented");
      }
  }
}
