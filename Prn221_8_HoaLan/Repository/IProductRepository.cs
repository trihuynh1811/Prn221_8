using DataAccessLayer.Model;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product SaveProduct(Product p);
        Product GetProductById(int id);
    }
}
