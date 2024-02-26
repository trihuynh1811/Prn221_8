﻿using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetUserByEmail(string email);
        bool checkExistUser(User user);
    }
}
