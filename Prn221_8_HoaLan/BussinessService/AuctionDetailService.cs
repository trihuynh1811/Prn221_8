using DataAccessLayer.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class AuctionDetailService : IAuctionDetailService
    {
        readonly IAuctionRepository auctionRepository;
        readonly IAuctionDetailRepository auctionDetailRepository;
        public AuctionDetailService(IAuctionRepository iauction, IAuctionDetailRepository iauctiondetail)
        {
            auctionDetailRepository = iauctiondetail;
            auctionRepository = iauction;
        }
        public List<AuctionDetail> GetAllAuctionDetail()
        {
            return auctionDetailRepository.GetAll();
        }

        public List<AuctionDetail> GetAllAuctionDetailByAuctionId(int AuctionId)
        {
            return auctionDetailRepository.GetAll();
        }
    }
}
