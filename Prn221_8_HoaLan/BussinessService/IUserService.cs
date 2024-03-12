using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public interface IUserService
    {
        public List<User> GetAllUser();
        public List<User> GetUserByRoleNameService(string RoleName);
        public List<User> GetActiveStaffSrv();
    }
}
