using System;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using HtmlAgilityPack;

namespace PriceNotifier
{
    public class GoogleShoppingScraper
    {
        private readonly string Url;
        private readonly string SearchTerm;
        public GoogleShoppingScraper(string searchTerm)
        {
            Url = $"https://www.google.com/search?tbm=shop&q={searchTerm}";
            this.SearchTerm = searchTerm;
        }

        public Product GetProductInformation()
        {
            var webGet = new HtmlWeb();
            var doc = webGet.Load(Url);
            var xPathToName = "//*[@id='ires']//h3[@class='r']/a";
            var name = doc.DocumentNode.SelectSingleNode(xPathToName);

            var xPathToPrice = "//*[@id='ires']//div[@class='_OA']//b";
            var price = doc.DocumentNode.SelectSingleNode(xPathToPrice);


            return new Product()
            {
                Upc = SearchTerm,
                Name = name.InnerText.Trim(),
                Price = double.Parse(price.InnerText.Trim().Substring(1))
            };
        }
    }
}