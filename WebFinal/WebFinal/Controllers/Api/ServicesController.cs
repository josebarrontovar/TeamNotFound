using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using WebFinal.Models;

namespace WebFinal.Controllers.Api
{
    public class ServicesController : ApiController
    {

        [HttpGet]
        public async Task<ClimaCity> Get(int id)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?id=" + id + "&appid=410aa6ce7a2e29f13f3b4dd7b9eec4f1";
            HttpClient client = new HttpClient();
            string content = await client.GetStringAsync(url);
            ClimaCity posts = JsonConvert.DeserializeObject<ClimaCity>(content);
            return posts;
        }



    }
}