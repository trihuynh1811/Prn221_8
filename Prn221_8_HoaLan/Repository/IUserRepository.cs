using DataAccessLayer.Model;
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
        public List<User> SearchUserByUserName(string searchValue);
        bool checkExistUser(User user);
        User? GetUserByUsernamePassword(string userName, string password);
        public List<User> SearchUserByUserNameAndRole(string searchValue, String Role);
        public List<User> GetUserByRoleName(String RoleName);
    }
}
