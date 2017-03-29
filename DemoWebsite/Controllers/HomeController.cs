using System.Collections.Generic;
using System.Web.Mvc;
using DemoWebsite.Code;
using DemoWebsite.Models;

namespace DemoWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataLayer _dataLayer;
        
        public HomeController()
        {
            _dataLayer = new DataLayer();
        }

        //Simple Grid with Ajax AddRow
        public ActionResult Index()
        {
            IList<ProductViewModel> productList = _dataLayer.LoadData();
            var model = new BasketViewModel{ProductList = productList};
            return View(model);
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

        //GridMvc
        public ActionResult GridMvc()
        {
            IList<ProductViewModel> productList = _dataLayer.LoadData();
            var model = new BasketViewModel { ProductList = productList };
            return View(model);
        }







    }
}