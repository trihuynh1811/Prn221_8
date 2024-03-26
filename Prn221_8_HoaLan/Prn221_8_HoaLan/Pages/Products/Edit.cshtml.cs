using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Model;
using BussinessService;

namespace Prn221_8_HoaLan.Pages.Products
{
    public class EditModel : PageModel
    {
        IProductService productService;
        public EditModel(IProductService iproduct)
        {
            productService = iproduct;
        }
        public Product Product { get; set; } = default!;

        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Quantity { get; set; }
        [BindProperty]
        public string Price { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var product = productService.getProductById(int.Parse(Id));
                product.Quantity = int.Parse(Quantity);
                product.Price = float.Parse(Price);
                productService.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
