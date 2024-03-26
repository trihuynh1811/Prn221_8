using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo;
        IAuctionRepository _auctionRepo;
        public UserService(IUserRepository IUserRepo, IAuctionRepository auctionRepo)
        {
            _userRepo = IUserRepo;
            _auctionRepo = auctionRepo;
        }

        public List<User> GetAllUser()
        {
            return _userRepo.GetAll();
        }

        public List<User> GetUserByRoleNameService(string RoleName)
        {
            return _userRepo.GetUserByRoleName(RoleName);
        }

        public List<User> GetActiveStaffSrv() // Lấy những staff mà hiện tại không quản lý đấu giá nào
        {
            var listStaff = GetUserByRoleNameService("Staff");
            List<User> filteredStaffList = listStaff
                .Where(s =>
                    !_auctionRepo.GetAll().Any(a => a.HostBy == s.UserId)  
                    || _auctionRepo.GetAll().All(a => a.HostBy != s.UserId || a.Status == "Finished") 
                )
                .ToList();
            return filteredStaffList;
        }
    }
}
