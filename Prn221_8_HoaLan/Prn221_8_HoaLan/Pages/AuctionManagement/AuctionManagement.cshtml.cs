using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionManagement
{

  public class AuctionManagementModel : PageModel
  {
    [BindProperty]
    public List<Product> Products { get; set; }

    public IActionResult OnGet()
    {
      // Mock data
      Products = new List<Product>{
        new Product
        {
          ProductId = 1,
                    Description = "Product 1 description",
                    Image = "https://example.com/image1.jpg",
                    Price = 10.0f,
                    ProductName = "Product 1",
                    Status = true,
                    Quantity = 5
        },
          new Product
          {
            ProductId = 2,
            Description = "Product 2 description",
            Image = "https://example.com/image2.jpg",
            Price = 20.0f,
            ProductName = "Product 2",
            Status = true,
            Quantity = 10
          },
          new Product
          {
            ProductId = 3,
            Description = "Product 3 description",
            Image = "https://example.com/image3.jpg",
            Price = 30.0f,
            ProductName = "Product 3",
            Status = true,
            Quantity = 15
          }
      };

      return Page();
    }
  }
}
