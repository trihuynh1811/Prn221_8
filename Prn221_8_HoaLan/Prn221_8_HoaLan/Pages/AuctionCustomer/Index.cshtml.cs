using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prn221_8_HoaLan.Pages.AuctionCustomer
{
    public class IndexModel : PageModel
    {
        IAuctionService _iAuctionSrv;
        IProductService productService;
        public List<Auction> Auctions;
        public List<String> ProductName;
        public IndexModel(IAuctionService auctionService, IProductService productService)
        {
            _iAuctionSrv = auctionService;
            this.productService = productService;
        }
        public IActionResult OnGet()
        {
            Auctions = (List<Auction>)_iAuctionSrv.GetAuctionByStatus("Ongoing");
            ProductName = new List<String>();
            if(Auctions!=null && Auctions.Count != 0)
            {
                for(int i=0; i<Auctions.Count; i++)
                    if (Auctions[i] != null && productService.getProductById(Auctions[i].Product) != null)
                    {
                        var product = productService.getProductById(Auctions[i].Product);
                        ProductName.Add(product.ProductName);
                    }
            }
            return Page();
        }
    }
}
