using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;

namespace Repository.BaseRepository
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);

        HoaLanContext GetContext();
    }
}
