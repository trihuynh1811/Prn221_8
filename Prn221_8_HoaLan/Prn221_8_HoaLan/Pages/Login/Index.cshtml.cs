using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Prn221_8_HoaLan.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly HoaLanContext _context;

        public LoginModel(IConfiguration configuration, HoaLanContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "User name is required.")]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var session = HttpContext.Session;

            // string adminUsername = _configuration["AdminAccount:Username"];
            // string adminPassword = _configuration["AdminAccount:Password"];
            User user = _context.Users.FirstOrDefault(x => x.UserEmail == Username && x.Password == Password);

            /* if (Email == adminUsername && Password == adminPassword)
             {
                 PresentationLayer.SessionExtensions.Set<String>(session, "Admin", "Admin");
                 return RedirectToPage("/Index");
             }*/
            if (user != null)
            {
                Prn221_8_HoaLan.SessionExtensions.Set<User>(session, "User", user);
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không đúng.");
                ViewData["ErrorMessage"] = "Thông tin đăng nhập không đúng.";
                return Page();
            }
        }
    }
}
