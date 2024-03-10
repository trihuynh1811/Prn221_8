using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessService.Request;
using DataAccessLayer.Model;
using Repository;

namespace BussinessService
{
    public class AuctionService : IAuctionService
    {
        readonly IAuctionRepository auctionRepository;
        readonly IProductRepository productRepository;

        public AuctionService(IAuctionRepository auctionRepository, IProductRepository productRepository)
        {
            this.auctionRepository = auctionRepository;
            this.productRepository = productRepository;
        }

        public Product CreateAuction(CreateUpdateProductDTO productDTO, CreateUpdateAuctionDTO auctionDTO)
        {
            Product product = new Product
            {
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                Description = productDTO.Description,
                Image = productDTO.Image,
                Status = productDTO.Status,
                IsAuction = productDTO.IsAuction==0?false:true,
                Quantity = productDTO.Quantity,
                UserId = productDTO.UserId,
            };

            try
            {
                product = productRepository.SaveProduct(product);
                Auction a = new Auction
                {
                    AuctionName = auctionDTO.AuctionName,
                    Product = product.ProductId,
                    CreateBy = auctionDTO.CreateBy,
                    Status = auctionDTO.Status,
                };
                auctionRepository.Save(a);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }

            return product;
        }

        public List<Auction> GetAllAuction()
        {
            return auctionRepository.GetAll();
        }
    }
}
