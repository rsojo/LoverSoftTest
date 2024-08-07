using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchasePageMVC.Mappers
{
    public class PurchaseMapper
    {
        /// <summary>
        /// Maps a list of products and a user ID to a Purchase entity.
        /// </summary>
        /// <param name="products">The list of products to be mapped.</param>
        /// <param name="UserId">The ID of the user making the purchase.</param>
        /// <returns>The mapped Purchase entity.</returns>
        public static Data.Entities.Purchase Map(List<Models.Product> products, int UserId)
        {
            var entity = new Data.Entities.Purchase
            {
                UserId = UserId,
                Date = DateTime.Now,
                Total = products.Sum(pp => pp.Price * pp.Quantity),
                PurchaseProducts = new List<Data.Entities.PurchaseProduct>()
            };
            entity.PurchaseProducts.AddRange(products.Select(pp => new Data.Entities.PurchaseProduct
            {
                ProductId = pp.Id,
                Quantity = pp.Quantity,
                Price = pp.Price
            }));

            entity.Total = entity.Total > 200 ? entity.Total - entity.Total * (decimal)0.05 : entity.Total;
            return entity;
        }
    }
}