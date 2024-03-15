using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuctionDetailRepository : BaseRepository<AuctionDetail>, IAuctionDetailRepository
    {
        public List<AuctionDetail> GetListAuctionDetailByAuctionId(int AuctionId)
        {
            return GetContext().AuctionDetails.Where(p=>p.AuctionId == AuctionId).ToList();
        }
    }
}
