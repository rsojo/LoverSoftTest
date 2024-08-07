using Business.DTO;
using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchasePageMVC.Services
{
    public class ProductService
    {
        private ProductRepository productRepo = new ProductRepository();
        
        public BusinessResponse<Models.Product> GetAll()
        {
            var ResponseProducts = productRepo.GetAll();
            var productList = new List<Models.Product>();
            if (ResponseProducts.Error == false)
            {
                productList = ResponseProducts.Lst.Select(p => new Models.Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Img = p.Img
                }).ToList();
            }
            return new BusinessResponse<Models.Product> { Error = ResponseProducts.Error, Lst = productList };
        }

    }
}