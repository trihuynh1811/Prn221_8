using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace Prn221_8_HoaLan.Pages.Staff.ManagementProduct
{
    public class ManageProductModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }

        IProductRepository _iproduct;
        public ManageProductModel(IProductRepository iProduct)
        {
            _iproduct = iProduct;
        }
        public IActionResult OnGet()
        {
            Products = _iproduct.GetAll();
            return Page();
        }
        public IActionResult OnPost()
        {
            var buttonValue = Request.Form["button"];
            bool StatusAction = true;
            if(buttonValue == "Reject")
            {
                StatusAction = false;
            }


            return Page();
        }
    }
}
