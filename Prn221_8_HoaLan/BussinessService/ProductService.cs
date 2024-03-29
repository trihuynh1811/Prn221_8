﻿using BussinessService.Request;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessService
{
    public class ProductService : IProductService
    {
        readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void CreateProduct(CreateUpdateProductDTO dto)
        {
            Product newPorduct = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Description = dto.Description,
                Image = dto.Image,
                Quantity = dto.Quantity,
                Status = dto.Status,
            };
            try
            {
                productRepository.SaveProduct(newPorduct);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public List<Product> getAllProduct()
        {
            return productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public void SetProductStatus(int id, string status)
        {
            try
            {
                Product? p = productRepository.GetById(id);
                p.Status = status;
                productRepository.Update(p);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public IQueryable<Product> GetProductsUsingContext()
        {
            return productRepository.GetContext().Products.Where(x => !x.IsAuction && x.Quantity > 0 && x.Status.Equals("approved"));
        }

        public IQueryable<Product> GetProductsUsingContextForStaff()
        {
            return productRepository.GetContext().Products.Where(x => !x.IsAuction);
        }

        public Product getProductById(int? id)
        {
            return productRepository.GetProductById(id);
        }

        public List<Product> GetProductsNotInAuctionAndInStock()
        {
            return productRepository.GetProductNotAuctionAndInStock();
        }

        public IQueryable<Product> GetProductsUsingContextByUserId(int id)
        {
            return productRepository.GetContext().Products.Where(x => x.UserId.Equals(id) && !x.IsAuction);
        }

        public void UpdateProduct(Product p)
        {
            productRepository.Update(p);
        }
    }
}
