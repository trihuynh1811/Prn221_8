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

        public bool checkExistUser(User user)
        {
            bool isUsernameExists = GetContext().Users.Any(u => u.UserName == user.UserName);
            bool isEmailExists = GetContext().Users.Any(u => u.UserEmail == user.UserEmail);
            bool isPhoneNumberExists = GetContext().Users.Any(u => u.PhoneNumber == user.PhoneNumber);
            if (isUsernameExists || isUsernameExists || isUsernameExists)
            {
                return true;
            }
            return false;
        }

        public User? GetUserByUsernamePassword(string userName, string password)
        {
            return GetContext().Users.SingleOrDefault(p => p.UserName == userName && p.Password == password);
        }
    }

}
