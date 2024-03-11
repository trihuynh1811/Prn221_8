using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public Auction GetAuctionById(int id)
        {
            return GetContext().Auctions.FirstOrDefault(p=>p.AuctionId == id);
        }

        public List<Auction> GetAuctionsByHostId(int hostId)
        {
            return GetContext().Auctions.Where(p => p.HostBy == hostId).ToList();
        }
    }
}
