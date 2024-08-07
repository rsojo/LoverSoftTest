﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchasePageMVC.Mappers
{
    public class ProductMapper
    {
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