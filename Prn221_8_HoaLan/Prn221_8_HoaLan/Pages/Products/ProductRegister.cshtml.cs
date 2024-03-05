using BussinessService.Request;
using BussinessService;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class ProductRegisterModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        public string? imageName = "";

        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public string ProductPrice { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [Required]
        [BindProperty]
        public string QuanityProduct { get; set; }


        public ProductRegisterModel(IHttpClientFactory httpClientFactory, IProductService IProductSrv)
        {
            _httpClientFactory = httpClientFactory;
            _productService = IProductSrv;
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
                        CreateUpdateProductDTO productDTO = new CreateUpdateProductDTO
                        {
                            ProductName = ProductName,
                            Price = float.Parse(ProductPrice),
                            Image = imageUrl,
                            Description = Description,
                            Status = false,
                            Quantity = int.Parse(QuanityProduct),
                        };
                        _productService.CreateProduct(productDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
            return Page();
        }
    }
}
