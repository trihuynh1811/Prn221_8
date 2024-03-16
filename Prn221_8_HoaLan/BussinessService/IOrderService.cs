﻿using BussinessService.Request;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public interface IOrderService
    {
        void CreateNewOrder(List<CreateOrderDTO> orderDTOList, User user);
    }
}