using System.Collections.Generic;
using System.Web.Mvc;
using MvcGridTest.Code;
using MvcGridTest.Models;

namespace MvcGridTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataLayer _dataLayer;

        public HomeController()
        {
            _dataLayer = new DataLayer();
        }

        public ActionResult Index()
        {
            List<ProductViewModel> productList = _dataLayer.LoadData();
            var productListViewModel = new BasketViewModel{ProductList = productList};
            return View(productListViewModel);
        }

        [HttpPost]
        public ActionResult Index(BasketViewModel model)
        {
            _dataLayer.SaveData(model.ProductList);
            return RedirectToAction("Index");   
        }
        
        public ActionResult AddRow()
        {
            var model = new ProductViewModel();
            return PartialView(model);
        }
    }
}