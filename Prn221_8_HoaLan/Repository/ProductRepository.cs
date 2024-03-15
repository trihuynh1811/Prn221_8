using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        //public List<Product> GetByUserId(int id)
        //{
        //    return GetAll()?.Where(x => x.UserId.Equals(id)).ToList();
        //}

        public Product? GetById(int id)
        {
            return GetAll()?.FirstOrDefault(x => x.ProductId == id);
        }

        public Product GetProductById(int? id)
        {
            return GetContext().Products.FirstOrDefault(p=>p.ProductId == id);
        }

        public List<Product> GetProductNotAuctionAndInStock()
        {
            return GetAll().Where(x => x.IsAuction == false && x.Quantity > 0).ToList();
        }

        public Product SaveProduct(Product p)
        {
            GetContext().Products.Add(p);

            GetContext().SaveChanges();

            return p;
        }
    }
}
