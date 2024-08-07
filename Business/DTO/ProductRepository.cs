using Business.DTO.Base;
using Business.Helpers;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.DTO
{
    public class ProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A BusinessResponse containing the retrieved product.</returns>
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
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }

            return response;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A BusinessResponse containing a list of all products.</returns>
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
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }

            return response;

        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="entity">The product to add.</param>
        /// <returns>A BusinessResponse containing the added product.</returns>
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
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }
            return response;

        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="entity">The product to delete.</param>
        /// <returns>A BusinessResponse containing the deleted product.</returns>
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
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }
            return response;
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="entity">The updated product.</param>
        /// <returns>A BusinessResponse containing the updated product.</returns>
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
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }
            return response;

        }
    }
}
