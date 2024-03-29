﻿using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        List<OrderDetail> GetAllByOrderId(int id);
    }
}
