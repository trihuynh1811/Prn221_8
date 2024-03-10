using DataAccessLayer.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo;
        public UserService(IUserRepository IUserRepo)
        {
            _userRepo = IUserRepo;
        }

        public List<User> GetAllUser()
        {
            return _userRepo.GetAll();
        }

        public List<User> GetUserByRoleNameService(string RoleName)
        {
            return _userRepo.GetUserByRoleName(RoleName);
        }
    }
}
