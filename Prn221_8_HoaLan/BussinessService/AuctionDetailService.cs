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
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUserRepository userRepository;

        public AuctionDetailService(IAuctionRepository iauction, IAuctionDetailRepository iauctiondetail, IOrderRepository iroder, IOrderDetailRepository orderDetailRepository, IUserRepository userRepository)
        {
            auctionDetailRepository = iauctiondetail;
            auctionRepository = iauction;
            orderRepository = iroder;
            this.orderDetailRepository = orderDetailRepository;
            this.userRepository = userRepository;
        }

        public string CheckBidPrice(float BidPrice, float CurrentPrice, float PriceStep)
        {
            try
            {
                if (BidPrice <= CurrentPrice)
                {
                    return "Bid Price must be greater than Start Price!";
                }
                if (BidPrice % PriceStep != 0)
                {
                    return "Bid Price must be a multiple of Price Step!";
                }
                return "No Error";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public bool EndBidAuction(int AuctionId)
        {
            try
            {
                Auction auction = auctionRepository.GetAuctionById(AuctionId);
                var auctionDetailTemp = auctionDetailRepository.GetAll()
                    .Where(ad => ad.AuctionId == auction.AuctionId && ad.BidTime <= auction.EndTime)
                    .OrderByDescending(ad => ad.ParticipantPrice)
                    .FirstOrDefault();
                if (auctionDetailTemp != null)
                {
                    auction.Status = "Finished";
                    auction.EndPrice = auctionDetailTemp.ParticipantPrice;

                    int WinnerId = (int)auctionDetailTemp.ParticipantId;
                    if (WinnerId != null)
                    {
                        auction.WinnerId = WinnerId;
                    }
                    auctionRepository.Update(auction);
                    //Chuyển qua orders table
                    Order order = new Order()
                    {
                        Status = false,
                        OrderDate = auctionDetailTemp.BidTime,
                        OrderBy = auctionDetailTemp.ParticipantId,
                    };
                    orderRepository.Save(order);
                    OrderDetail oderDetail = new OrderDetail()
                    {
                        Quantity = 1,
                        Orders = order.OrderId,
                        Product = auction.Product,
                    };
                    orderDetailRepository.Save(oderDetail);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<AuctionDetail> GetAllAuctionDetail()
        {
            return auctionDetailRepository.GetAll();
        }

        public List<AuctionDetail> GetAllAuctionDetailByAuctionId(int AuctionId)
        {
            return auctionDetailRepository.GetAll().Where(p => p.AuctionId == AuctionId).OrderByDescending(p => p.ParticipantPrice).ToList();
        }

        public float GetCurrentPriceSrv(int AuctionId)
        {
            var auctionDetailTemp = auctionDetailRepository.GetListAuctionDetailByAuctionId(AuctionId);
            if (auctionDetailTemp == null || !auctionDetailTemp.Any())
            {
                return (float)auctionRepository.GetAuctionById(AuctionId).StartPrice;
            }
            var auction = auctionRepository.GetAuctionById(AuctionId);
            return auctionDetailRepository.GetListAuctionDetailByAuctionId(AuctionId).Where(p=>p.BidTime<auction.EndTime)
            .OrderByDescending(a => a.ParticipantPrice)
            .FirstOrDefault().ParticipantPrice;
        }

        public void InsertBidToAuctionDetail(int UserId, int AuctionId, float PriceBid, DateTime BidTime)
        {
            try
            {
                AuctionDetail autionDetailTemp = new AuctionDetail()
                {
                    AuctionId = AuctionId,
                    ParticipantId = UserId,
                    ParticipantPrice = PriceBid,
                    BidTime = BidTime
                };
                auctionDetailRepository.Save(autionDetailTemp);
            }
            catch (Exception ex)
            {

            }
        }

        public List<String> GetListUserNameInAuctionDetail(int AuctionId)
        {
            try
            {
                var listAuctionDetail = GetAllAuctionDetailByAuctionId(AuctionId);
                List<String> participants = new List<String>();
                foreach (var item in listAuctionDetail)
                {
                    var user = userRepository.GetUserById((int)item.ParticipantId);
                    participants.Add(user.LastName+" "+user.FirstName);
                }
                return participants;
            }
            catch (Exception ex)
            {
                return new List<String>();
            }
        }
    }
}
