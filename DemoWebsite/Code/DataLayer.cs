using System.Collections.Generic;
using DemoWebsite.Models;

namespace DemoWebsite.Code
{
    public class DataLayer
    {
        private const string Path = @"C:\Git\Source\Demo\DemoWebsite\DataDummy.txt";
            //@"F:\Documents\Visual Studio 2015\Projects\Demo\DemoWebsite\DataDummy.txt";

        public IList<ProductViewModel> LoadData()
        {
            string text = System.IO.File.ReadAllText(Path);
            var productList = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<ProductViewModel>>(text);
            return productList;
        }

        public void SaveData(IList<ProductViewModel> productList)
        {
            var textToSave = Newtonsoft.Json.JsonConvert.SerializeObject(productList);
            System.IO.File.WriteAllText(Path, textToSave);
        }
    }
}