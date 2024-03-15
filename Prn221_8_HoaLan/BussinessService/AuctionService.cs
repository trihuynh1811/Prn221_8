using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessService.Request;
using DataAccessLayer.Model;
using Microsoft.Identity.Client;
using Repository;

namespace BussinessService
{
    public class AuctionService : IAuctionService
    {
        readonly IAuctionRepository auctionRepository;
        readonly IProductRepository productRepository;
        readonly IUserRepository userRepository;
        public AuctionService(IAuctionRepository auctionRepository, IProductRepository productRepository, IUserRepository iuser)
        {
            this.auctionRepository = auctionRepository;
            this.productRepository = productRepository;
            userRepository = iuser;
        }

        public bool AssignToStaff(int StaffId, int AuctionId)
        {
            try
            {
                var auction = auctionRepository.GetAuctionById(AuctionId);
                auction.HostBy = StaffId;
                auctionRepository.Update(auction);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
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
                IsAuction = productDTO.IsAuction == 0 ? false : true,
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

        public List<Auction> GetAllAssignedAuction()
        {
            return auctionRepository.GetAll().Where(p => p.HostBy == null).ToList();
        }

        public List<Auction> GetAllAuction()
        {
            return auctionRepository.GetAll();
        }

        public List<Auction> GetAuctionByHostId(int hostId)
        {
            return auctionRepository.GetAll().Where(p => p.HostBy == hostId).ToList();
        }

        public Auction GetAuctionById(int id)
        {
            return auctionRepository.GetAuctionById(id);
        }
        public string checkRegisterAuctionFromStaff(float StartPrice, float PriceStep, DateTime StartTime, DateTime EndTime)
        {
            DateTime currentTime = DateTime.Now;
            if (StartTime <= currentTime)
            {
                return "The Start time must be greater than the current time";
            }
            if (StartTime >= EndTime)
            {
                return "The start time must be less than the end time";
            }
            return "No error";
        }
        public bool registerAuctionFromStaff(int AuctionId, float StartPrice, float PriceStep, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                var auction = auctionRepository.GetAuctionById(AuctionId);
                if (auction == null)
                {
                    throw new Exception($"Not found auction by id: {AuctionId}");
                }
                auction.StartPrice = StartPrice;
                auction.PriceStep = PriceStep;
                auction.StartTime = StartTime;
                auction.EndTime = EndTime;
                auction.Status = "Upcomming";
                auctionRepository.Update(auction);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Auction> SearchAuctoionByAuctionNameAndStatus(int hostId, string searchValue, string StatusAuction)
        {
            if ("All".Equals(StatusAuction))
            {
                if (searchValue == null)
                {
                    searchValue = "";
                }
                return auctionRepository.GetAll()
                                    .Where(
                                            auction => auction.HostBy == hostId && auction.AuctionName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                           ).ToList();
            }
            if (searchValue == null)
            {
                searchValue = "";
            }
            if (StatusAuction == null)
            {
                StatusAuction = "";
            }
            return auctionRepository.GetAll()
                                    .Where(
                                            auction => auction.HostBy == hostId && auction.Status.ToString().Equals(StatusAuction)
                                            && auction.AuctionName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            ).ToList();
        }

        public bool ChangeStatusAuction(int AuctionId, string status)
        {
            try
            {
                var auction = auctionRepository.GetAll().FirstOrDefault(a => a.AuctionId == AuctionId);
                if (auction == null)
                {
                    return false;
                }
                auction.Status = status;
                auctionRepository.Update(auction);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Auction> GetAuctionByStatus(string status)
        {
            return (List<Auction>)auctionRepository.GetAll().Where(p => status.Equals(p.Status)).ToList();
        }

        public string GetNameByAuctionId(int AuctionId, int UserId)
        {
            var auction = auctionRepository.GetAuctionById(AuctionId);
            User user = (User)userRepository.GetUserById((int)UserId);
            return user.LastName + " " + user.FirstName;
        }
    }
}
