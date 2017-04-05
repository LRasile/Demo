using DemoFramework.Code;
using DemoFramework.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace DemoFramework.Controllers
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
            var model = new BasketViewModel { ProductList = productList };
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