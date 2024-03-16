using BussinessService.Request;
using DataAccessLayer.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }

        public void CreateNewOrder(List<CreateOrderDTO> orderDTOList, User user)
        {

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = false,
                OrderBy = user.UserId,
                IsAuction = false,
            };

            order = orderRepository.SaveOrder(order);

            foreach (CreateOrderDTO dto in orderDTOList)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = dto.quantity,
                    Orders = order.OrderId,
                    Product = dto.pId
                };
                orderDetailRepository.Save(orderDetail);
            }
            foreach (CreateOrderDTO dto in orderDTOList)
            {
                Product p = productRepository.GetProductById(dto.pId);
                p.Quantity -= dto.quantity;
                productRepository.Save(p);
            }
        }

        public List<OrderDetail> GetAllOrderDetailByOrderId(int id)
        {
            return orderDetailRepository.GetAllByOrderId(id);
        }

        public List<Order> GetOrdersByUser(User user)
        {
            return orderRepository.GetAllOrdersByUser(user);
        }
    }
}
