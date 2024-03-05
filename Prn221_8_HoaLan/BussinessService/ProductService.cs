using BussinessService.Request;
using DataAccessLayer.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class ProductService : IProductService
    {
        readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void CreateProduct(CreateUpdateProductDTO dto)
        {
            Product newPorduct = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Description = dto.Description,
                Image = dto.Image,
                Quantity = dto.Quantity,
                Status = dto.Status,
            };
            try
            {
                productRepository.SaveProduct(newPorduct);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}
