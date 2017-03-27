using System.Collections.Generic;
using MvcGridTest.Models;

namespace MvcGridTest.Code
{
    public class DataLayer
    {
        private const string Path =
            @"F:\Documents\Visual Studio 2015\Projects\Demo\DemoWebsite\Code\DataDummy.txt";

        public List<ProductViewModel> LoadData()
        {
            string text = System.IO.File.ReadAllText(Path);
            var productList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductViewModel>>(text);
            return productList;
        }

        public void SaveData(List<ProductViewModel> productList)
        {
            var textToSave = Newtonsoft.Json.JsonConvert.SerializeObject(productList);
            System.IO.File.WriteAllText(Path, textToSave);
        }
    }
}