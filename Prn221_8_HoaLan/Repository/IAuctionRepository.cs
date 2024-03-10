using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuctionRepository : IBaseRepository<Auction>
    {
        List<Auction>? GetByUserId(int userId);
    }
}
