using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace Prn221_8_HoaLan.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _user;

        public LoginModel(IConfiguration configuration, IUserRepository User)
        {
            _configuration = configuration;
            _user = User;
        }

        [BindProperty]
        [Required(ErrorMessage = "User name is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var session = HttpContext.Session;
            User user = _user.GetUserByUsernamePassword(Username, Password);
            if (user != null)
            {
                Prn221_8_HoaLan.SessionExtensions.Set<User>(session, "User", user);
                if (user.Role == 2) //Staff
                {
                    return RedirectToPage("../Staff/AuctionManagement/index");
                }
                return RedirectToPage("/Index");
            }
            else if (_configuration.GetSection("AdminAccount")["Username"].Equals(Username) && _configuration.GetSection("AdminAccount")["Password"].Equals(Password))
            {
                Prn221_8_HoaLan.SessionExtensions.Set<string>(session, "Admin", Username);
                return RedirectToPage("../Admin/ManageUser/Detail");
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
