using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Order SaveOrder(Order order);
    }
}
