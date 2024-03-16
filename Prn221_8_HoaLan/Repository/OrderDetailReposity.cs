using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailReposity : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public List<OrderDetail> GetAllByOrderId(int id)
        {
            return GetContext().OrderDetails.Include(x => x.ProductNavigation).Where(x => x.Orders.Equals(id)).ToList();
        }
    }
}
