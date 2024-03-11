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
        public List<Auction> GetAllAssignedAuction();
        public Auction? GetAuctionById(int id);

        public bool AssignToStaff(int StaffId, int AuctionId);
        public List<Auction> GetAuctionByHostId(int hostId);
    }
}
