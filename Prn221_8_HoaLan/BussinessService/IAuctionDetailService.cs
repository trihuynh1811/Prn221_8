using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public interface IAuctionDetailService
    {
        List<AuctionDetail> GetAllAuctionDetail();
        List<AuctionDetail> GetAllAuctionDetailByAuctionId(int AuctionId);

    }
}
