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

        public void CreateNewOrder(OrderListDTO orderDTOList, User user)
        {

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                Status = false,
                OrderBy = user.UserId,
                IsAuction = false,
                TotalPrice = orderDTOList.totalPrice 
            };

            order = orderRepository.SaveOrder(order);

            foreach (CreateOrderDTO dto in orderDTOList.products)
            {
                Product p = productRepository.GetById(dto.pId);
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = dto.quantity,
                    Orders = order.OrderId,
                    Product = dto.pId,
                    TotalPrice = p.Price * dto.quantity
                };
                orderDetailRepository.Save(orderDetail);
            }
            foreach (CreateOrderDTO dto in orderDTOList.products)
            {
                Product p = productRepository.GetProductById(dto.pId);
                p.Quantity -= dto.quantity;
                productRepository.Update(p);
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
