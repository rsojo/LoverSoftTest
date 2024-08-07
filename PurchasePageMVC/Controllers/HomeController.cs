using Business.DTO;
using Data.Entities;
using PurchasePageMVC.Models;
using PurchasePageMVC.Security;
using PurchasePageMVC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PurchasePageMVC.Controllers
{
    [SessionValidate]
    public class HomeController : Controller
    {
        private static List<PurchasePageMVC.Models.Product> productList;   
        
        public ActionResult Index()
        {
            ProductService productService = new ProductService();
            
            var ResponseProducts = productService.GetAll();

            
            if (ResponseProducts.Error == false)
            {
                productList = ResponseProducts.Lst;
                return View(ResponseProducts.Lst);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Purchase(List<PurchasePageMVC.Models.PurchaseProduct> PurchaseProduct)
        {
            productList = productList.Where(p => PurchaseProduct.Select(pp => pp.ProductId).Contains(p.Id))
                                              .Select(p => new PurchasePageMVC.Models.Product { Id = p.Id, Description=p.Description, Price = p.Price, Img  = p.Img,   Name   = p.Name ,Quantity = PurchaseProduct.First(pp => pp.ProductId == p.Id).Quantity })
                                              .ToList();

            var user = (User)Session["User"];
            Session["User"] = user;
            PurchaseRepository purchaseRepository = new PurchaseRepository();
            purchaseRepository.SetWithRelations(Mappers.PurchaseMapper.Map(productList, user.Id));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Purchase()
        {


            return View(productList);
        }
        


      
    }
}