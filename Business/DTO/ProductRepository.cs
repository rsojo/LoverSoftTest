using Business.DTO.Base;
using Business.Helpers;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.DTO
{
    public class ProductRepository : IRepository<Product>
    {

        public BusinessResponse<Product> Get(int id)
        {
            var response = new BusinessResponse<Product>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    response.UnitResp = dbContext.Products.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }

            return response;
        }

        public BusinessResponse<Product> GetAll()
        {
            var response = new BusinessResponse<Product>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    response.Lst = new List<Product>();
                    response.Lst.AddRange(dbContext.Products.ToList());
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }

            return response;

        }

        public BusinessResponse<Product> Set(Product entity)
        {
            var response = new BusinessResponse<Product>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    dbContext.Products.Add(entity);
                    dbContext.SaveChanges();
                }
                response.UnitResp = entity;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }
            return response;

        }

        public BusinessResponse<Product> Delete(Product entity)
        {
            var response = new BusinessResponse<Product>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    dbContext.Products.Remove(entity);
                    dbContext.SaveChanges();
                }
                response.UnitResp = entity;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }
            return response;
        }
        public BusinessResponse<Product> Update(Product entity)
        {
            var response = new BusinessResponse<Product>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    var existingProduct = dbContext.Products.FirstOrDefault(p => p.Id == entity.Id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = entity.Name;
                        existingProduct.Price = entity.Price;
                        existingProduct.Description = entity.Description;
                        dbContext.SaveChanges();
                    }
                }
                response.UnitResp = entity;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }
            return response;
           
        }
    }
}
