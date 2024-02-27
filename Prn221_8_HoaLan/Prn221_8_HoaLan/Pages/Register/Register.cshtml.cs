using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prn221_8_HoaLan.Pages.Login;
using System.ComponentModel.DataAnnotations;
using Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prn221_8_HoaLan.Pages.Register
{
    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepo;

        public RegisterModel(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepo = userRepository;
        }

        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newUser = new User
            {
                Address = Address,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                PhoneNumber = PhoneNumber,
                UserEmail = Email,
                UserName = UserName,
                Status = true,
                Role = 1
            };
            if (_userRepo.checkExistUser(newUser))
            {
                ViewData["Message"] = "Tài khoản đã tồn tại.";
                return Page();
            }
            else
            {
                _userRepo.Save(newUser);
                ViewData["Message"] = "Đăng ký thành công!";
                return RedirectToPage("/Index");
            }
        }


    }
}
