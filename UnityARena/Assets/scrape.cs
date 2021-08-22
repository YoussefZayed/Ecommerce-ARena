using System;
using RestSharp;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    class scrape : MonoBehaviour
    {

        public Product getProduct(String url)

        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response.Content);


            Regex regex = new Regex("[^a-zA-Z0-9 .,]|(?<!\\d)[.,]|[.,](?!\\d)");
            Regex dimensionsRegex = new Regex("[^0-9 .,]|(?<!\\d)[.,]|[.,](?!\\d)");

            var price = regex.Replace(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='price_inside_buybox']").InnerHtml, "");

            var title = regex.Replace(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='productTitle']").InnerHtml, "");

            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='productDetails_techSpec_section_1']")[0].ChildNodes;

            var dimensionsIndex = 0;

            foreach (HtmlNode node in nodes)
            {
                if (regex.Replace(node.InnerHtml,"").Contains("Item Dimensions L x W x H"))
                {
                    dimensionsIndex = nodes.GetNodeIndex(node);
                }
            }

            var dimensions = dimensionsRegex.Replace(nodes[dimensionsIndex].InnerHtml, "").Trim();

            // var imageLink = regex.Replace(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='landingImage']").OuterHtml, "");

            var productType = "unknown";

            if (title.IndexOf("monitor", StringComparison.OrdinalIgnoreCase) >= 0)
            { productType = "monitor"; }
            else if (title.IndexOf("tv", StringComparison.OrdinalIgnoreCase) >= 0)
            { productType = "tv"; }

            // return new Product(title, price, dimensions, productType, imageLink);
            return new Product(title, price, dimensions, productType);
        }

        public List<Product> getProducts(List<String> urls)
        {
            //var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            //driver.Navigate().GoToUrl("https://www.amazon.ca/s?k=" + item + "&ref=nb_sb_noss_");

            //var elements = driver.FindElements(By.XPath("//div[@class='a-link-normal s-no-outline']"));

            //foreach (IWebElement element in elements)
            //{
                //.Add(getUrl(element,driver));
            //}

            return urls.ConvertAll(new Converter<string, Product>(getProduct));
        }

        public  Dictionary<String, String> toDictionary(Product product)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(JsonConvert.SerializeObject(product));
        }

        public  List<Dictionary<String,String>> getDictionaries(List<Product> products)
        {
            return products.ConvertAll(new Converter<Product, Dictionary<String, String>>(toDictionary));
        }

        // public static void Main(string[] args)
        // {
        //     Console.WriteLine(getProducts(new List<string> { "https://api.webscrapingapi.com/v1?api_key=8dplouf5IVVK6AZWPa83akQvrRlnXMIu&url=https%3A%2F%2Fwww.amazon.ca%2FAcer-32-IPS-Monitor-2560x1440%2Fdp%2FB07X6KJKNZ%2Fref%3Dsr_1_12%3Fdchild%3D1%26keywords%3Dmonitors%26qid%3D1629617818%26sr%3D8-12&method=GET&device=desktop&proxy_type=datacenter" })[0].Dimensions);
        //     Console.ReadLine();
        // }

        //public static String getUrl(IWebElement element, IWebDriver driver)
        //{

            //var id = element.GetDomAttribute("data-asin");

                //return " ";

        //}

    }

    public class Product
    {

        // public Product(String title, String price, String dimensions, String type, String imageLink)
        public Product(String title, String price, String dimensions, String type)
        {
            Title = title;
            Price = price;
            Dimensions = dimensions;
            ProductType = type;
            // ImageLink = imageLink;
        }
        public string Title { set; get; }
        public string Price { set; get; }
        public string Dimensions { set; get; }
        public string ProductType { set; get; }
        // public string ImageLink { set; get; }

    }


