using DataAccessLayer.Model;
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
        public List<Auction>? GetByUserId(int userId)
        {
            return GetAll()?.Where(x => x.CreateBy.Equals(userId)).ToList();
        }
    }
}
