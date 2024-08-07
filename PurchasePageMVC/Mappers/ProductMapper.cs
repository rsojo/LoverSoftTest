using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchasePageMVC.Mappers
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps a Data.Entities.Product object to a Models.Product object.
        /// </summary>
        /// <param name="product">The Data.Entities.Product object to be mapped.</param>
        /// <returns>The mapped Models.Product object.</returns>
        public static Models.Product Map(Data.Entities.Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img
            };
        }

        /// <summary>
        /// Maps a Models.Product object to a Data.Entities.Product object.
        /// </summary>
        /// <param name="product">The Models.Product object to be mapped.</param>
        /// <returns>The mapped Data.Entities.Product object.</returns>
        public static Data.Entities.Product Map(Models.Product product)
        {
            return new Data.Entities.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img
            };
        }
    }
}