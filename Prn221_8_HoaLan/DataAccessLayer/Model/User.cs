using System;
using System.Collections.Generic;

namespace DataAccessLayer.Model
{
    public partial class User
    {
        public User()
        {
            AuctionDetails = new HashSet<AuctionDetail>();
            Orders = new HashSet<Order>();
            Reports = new HashSet<Report>();
        }

        public int UserId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int? Role { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<AuctionDetail> AuctionDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
