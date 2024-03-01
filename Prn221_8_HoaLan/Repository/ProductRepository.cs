﻿using DataAccessLayer.Model;
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
        public Product SaveProduct(Product p)
        {
            GetContext().Products.Add(p);

            GetContext().SaveChanges();

            return p;
        }
    }
}