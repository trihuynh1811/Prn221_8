﻿using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuctionRepository : IBaseRepository<Auction>
    {
        Auction GetAuctionById(int id);
        List<Auction> GetAuctionsByHostId(int hostId);
        List<Auction>? GetByUserId(int userId);
    }
}
