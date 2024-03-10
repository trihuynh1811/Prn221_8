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

        public Product CreateAuction(CreateUpdateProductDTO pDto, CreateUpdateAuctionDTO aDto)
        {
            Product p = new Product
            {
                ProductName = pDto.ProductName,
                Price = pDto.Price,
                Description = pDto.Description,
                Image = pDto.Image,
                Status = pDto.Status,
            };

            try
            {
                p = productRepository.SaveProduct(p);
                Auction a = new Auction
                {
                    AuctionName = aDto.AuctionName,
                    Price = aDto.Price,
                    Status = aDto.Status,
                    Product = p.ProductId,
                    Quantity = pDto.Quantity,
                    CreateBy = aDto.CreateBy
                };
                auctionRepository.Save(a);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }

            return p;
        }

        public List<Auction> GetAllAuction()
        {
            return auctionRepository.GetAll();
        }

        public List<Auction>? GetByUserId(int id)
        {
            return auctionRepository.GetByUserId(id);
        }
    }
}
