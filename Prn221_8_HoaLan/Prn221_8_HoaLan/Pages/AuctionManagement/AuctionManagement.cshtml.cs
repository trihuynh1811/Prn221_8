using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repository;

namespace Prn221_8_HoaLan.Pages.AuctionManagement
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class AuctionManagementModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IProductRepository productRepository;

        public AuctionManagementModel(IProductService productService, IProductRepository productRepository)
        {
            this.productService = productService;
            this.productRepository = productRepository;
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        public List<Auction> Auctions { get; set; }

        public IActionResult OnGet()
        {
            Products = productService.GetProducts();

            return Page();
        }

        public async Task<IActionResult> OnPostApproveDecline()
        {
            string requestBody = string.Empty;
            int id;
            string status = "";
            ApproveDeclineModel model;
            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
                model = JsonConvert.DeserializeObject<ApproveDeclineModel>(requestBody);
                id = model.id;
                status = model.status;
            }
            if (id > 0 && !status.Equals(""))
            {
                id = model.id;
                status = model.status;
                productService.SetProductStatus(id, status);
            }

            return new ContentResult
            {
                StatusCode = 200
            };
        }
    }
}


public class ApproveDeclineModel
{
    public int id { get; set; }
    public string status { get; set; }
}