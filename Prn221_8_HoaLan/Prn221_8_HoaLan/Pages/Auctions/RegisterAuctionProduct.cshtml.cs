using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using BussinessService.Request;
using BussinessService;
using Repository;
using DataAccessLayer.Model;

namespace Prn221_8_HoaLan.Pages.Auctions
{
    public class RegisterAuctionProductModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuctionService auctionService;
        public string? imageName = "";

        [BindProperty]
        public string AuctionName { get; set; }

        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public string ProductDesc { get; set; }

        public string Msg { get; set; }

        public RegisterAuctionProductModel(IHttpClientFactory httpClientFactory, IAuctionService auctionService)
        {
            _httpClientFactory = httpClientFactory;
            this.auctionService = auctionService;
        }

        public IActionResult OnGet()
        {
            var customer = HttpContext.Session.Get("User");
            if (customer == null)
            {
                return RedirectToPage("../Login/Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(IFormFile imageFile)
        {

            var httpClient = _httpClientFactory.CreateClient();
            var clientSecret = "c75a7c6cf6f9c5fb9e79c7f00098a55e80163387";
            var clientId = "cb2bb6bdf2aedbf";
            var apiUrl = "https://api.imgur.com/3/image";
            string? imageUrl = "";

            var session = HttpContext.Session;
            User user = Prn221_8_HoaLan.SessionExtensions.Get<User>(session, "User");
            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Client-ID {clientId}");
                var content = new MultipartFormDataContent
                {
                    { new StreamContent(imageFile.OpenReadStream()), "image", imageFile.FileName }
                };

                var response = await httpClient.PostAsync(apiUrl, content);

                // Process the response, handle errors, etc.
                if (response.IsSuccessStatusCode)
                {
                    var uploadResponse = await response.Content.ReadFromJsonAsync<ImgurUploadResponse>();
                    if (uploadResponse != null)
                    {
                        imageUrl = uploadResponse.data?.link;
                        CreateUpdateProductDTO ProductDTO = new CreateUpdateProductDTO
                        {
                            ProductName = ProductName,
                            Price = 0,
                            Image = imageUrl,
                            Description = ProductDesc,
                            IsAuction = 1,
                            Quantity = 1,
                            UserId = user.UserId
                        };
                        CreateUpdateAuctionDTO AuctionDTO = new CreateUpdateAuctionDTO
                        {
                            AuctionName = AuctionName,
                            CreateBy = user.UserId
                        };
                        Product p = auctionService.CreateAuction(ProductDTO, AuctionDTO);
                        Msg = "Successfully register auction";
                        return Page();
                    }
                    Msg = "Can't register this auction please try again!";
                    return Page();
                }
            }catch(Exception ex)
            {
                Msg = "Can't register this auction please try again!";
                return Page();
            }
            return Page();
        }
    }
}

public class ImgurUploadResponse
{
    public int? status { get; set; }
    public ImgurResponseData? data { get; set; }
}

public class ImgurResponseData
{
    public string? id { get; set; }
    public string? link { get; set; }
}
