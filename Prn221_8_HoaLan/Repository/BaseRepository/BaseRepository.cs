using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HoaLanContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new HoaLanContext();
            dbSet = context.Set<T>();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Save(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public HoaLanContext GetContext()
        {
            return context;
        }
    }
}
