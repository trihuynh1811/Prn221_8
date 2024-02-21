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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User? GetUserByEmail(string email)
        {
            return GetAll()?.Find(user => user.UserEmail == email);
        }

        public override List<User> GetAll()
        {
            return GetContext().Users.Include(user => user.Orders).ToList();
        }
    }

}
