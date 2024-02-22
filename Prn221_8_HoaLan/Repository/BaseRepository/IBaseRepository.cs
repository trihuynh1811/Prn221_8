﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BaseRepository
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
