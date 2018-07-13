using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebFinal.Models;

namespace WebFinal.ViewModels
{
    public class FormsViewModel
    {

        public DataForm DataForm { get; set; }
        public List<City> ListofCity { get; set; }
        
        public FormsViewModel()
        {
            ListofCity = new List<City>();
            //City x = new City
            //{
            //    Id = 1,
            //    Name = "JA",
            //    Country = "Mexico"
            //};

            List<City> posts = Task.Run(CallApi).Result;
            foreach(var item in posts)
            {
                ListofCity.Add(item);
            }
          
        }
        private async static Task<List<City>> CallApi()
        {
            string data = await GetData();

            List<City> posts = DeserializeData(data);

            return posts;
        }

        private static List<City> DeserializeData(string data)
        {
            List<City> posts = JsonConvert.DeserializeObject<List<City>>(data);

            return posts;
        }


        private async static Task<string> GetData()
        {
            string url = "http://middleware-neoris.s3-website-us-west-1.amazonaws.com/";

            HttpClient client = new HttpClient();

            var content = await client.GetStringAsync(url);

            return content;
        }

    }
}