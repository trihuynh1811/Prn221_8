using BussinessService.Request;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public interface IAuctionService
    {
        public Product CreateAuction(CreateUpdateProductDTO pDto, CreateUpdateAuctionDTO aDto);
        public List<Auction> GetAllAuction();
        public List<Auction> GetAuctionByStatus(string status);
        public List<Auction> GetAllAssignedAuction();
        public Auction GetAuctionById(int id);

        public bool AssignToStaff(int StaffId, int AuctionId);
        public List<Auction> GetAuctionByHostId(int hostId);
        public string checkRegisterAuctionFromStaff(float StartPrice, float PriceStep, DateTime StartTime, DateTime EndTime);
        public bool registerAuctionFromStaff(int AuctionId, float StartPrice, float PriceStep, DateTime StartTime, DateTime EndTime );
        public List<Auction> SearchAuctoionByAuctionNameAndStatus(int hostId, string searchValue, String StatusAuction);
        public bool ChangeStatusAuction(int AuctionId, string status);
        public string GetNameByAuctionId(int AuctionId, int UserId);
        public List<Auction> GetAuctionByProductOwnerId(int productOwnerId);
        public List<string> getStaffsInAuction(List<Auction> auctions);
        public List<string> getProductOnersNameInAuction(List<Auction> auctions);
        public bool checkTime(int auctionId, string status);
    }
}
