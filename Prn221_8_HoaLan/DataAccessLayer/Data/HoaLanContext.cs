using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class HoaLanContext : DbContext
    {
        public HoaLanContext(DbContextOptions<HoaLanContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Auction>? Auctions { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Report>? Reports { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<AuctionDetail>? AuctionDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true, true).Build();
            options.UseSqlServer(configuration.GetConnectionString("HoaLan"));

        }
    }
}
