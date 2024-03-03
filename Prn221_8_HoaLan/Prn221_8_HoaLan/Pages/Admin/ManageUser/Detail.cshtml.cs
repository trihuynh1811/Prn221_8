using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace Prn221_8_HoaLan.Pages.Admin.UserInformationManager
{
    public class DetailModel : PageModel
    {
        private readonly IUserRepository _iuser;

        [BindProperty]
        public List<User> ListUser { get; set; }

        [BindProperty]
        public string SearchValue {  get; set; }

        [BindProperty]
        public string RoleValue { get; set; }

        public DetailModel(IUserRepository UserRepo) 
        {
            _iuser = UserRepo;
        }

        public IActionResult OnGet()
        {
            var session = HttpContext.Session;
            if(session == null)
            {
                return RedirectToPage("../../NoAuthorization");
            }
            string admin = Prn221_8_HoaLan.SessionExtensions.Get<string>(session, "Admin");
            if(admin == null)
            {
                return RedirectToPage("../../NoAuthorization");
            }
            if (SearchValue == null || SearchValue == "") {
                ListUser = _iuser.GetAll();
            }
            else
            {
                ListUser = _iuser.SearchUserByUserName(SearchValue);
            }
            return Page();
        }

        public PageResult OnPost()
        {
            ListUser = _iuser.SearchUserByUserNameAndRole(SearchValue, RoleValue);
            return Page();
        }
    }
}
