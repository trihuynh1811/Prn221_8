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
        float GetCurrentPriceSrv(int AuctionId);
        string CheckBidPrice(float BidPrice, float CurrentPrice, float StepPrice);
        public void InsertBidToAuctionDetail(int UserId, int AuctionId, float PriceBid, DateTime BidTime);
        public bool EndBidAuction(int AuctionId);
        public List<String> GetListUserNameInAuctionDetail(int AuctionId);
    }
}
