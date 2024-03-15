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
                Product p = productRepository.GetProductById(dto.pId);
                p.Quantity -= dto.quantity;
                orderDetailRepository.Save(orderDetail);
                productRepository.Save(p);
            }
        }
    }
}
