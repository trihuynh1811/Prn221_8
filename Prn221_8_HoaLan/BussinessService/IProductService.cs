using BussinessService.Request;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public interface IProductService 
    {
        public void CreateProduct(CreateUpdateProductDTO dto);

        public List<Product> GetProducts();

        public Product GetById(int id);

        public void SetProductStatus(int id, string status);
    }
}
