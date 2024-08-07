using Business.DTO;
using System.Web.Mvc;

namespace PurchasePageMVC.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository productRepo = new ProductRepository();
        public ActionResult Index()
        {
          
            var ResponseProducts = productRepo.GetAll();

            if (ResponseProducts.Error == false)
            {
                return View(ResponseProducts.Lst);
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}