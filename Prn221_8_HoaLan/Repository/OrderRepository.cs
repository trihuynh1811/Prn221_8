using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public List<Order> GetAllOrdersByUser(User user)
        {
            return GetAll().Where(x => x.OrderBy.Equals(user.UserId)).ToList();
        }

        public Order SaveOrder(Order order)
        {
            GetContext().Orders.Add(order);

            GetContext().SaveChanges();

            return order;
        }
    }
}
