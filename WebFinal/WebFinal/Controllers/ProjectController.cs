using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebFinal.Controllers.Api;
using WebFinal.Models;
using WebFinal.ViewModels;

namespace WebFinal.Controllers
{
    public class ProjectController : Controller
    {
        #region Prop
        public List<City> dataCity = new List<City>();
        public ClimaCity dataClimaCity = new ClimaCity();
        private DataContext context;
        public string responseString { get; set; }
        public string iconID { get; set; }
        public string Temperature { get; set; }
        public string TemperatureMax { get; set; }
        public string DescriptionCould { get; set; }
        #endregion
        public ProjectController()
        {
            context = new DataContext();
            dataCity = new List<City>();
        }

        // GET: Project
        public ActionResult Index()
        {
            FormsViewModel forms = new FormsViewModel();
            return View(forms);
        }

        [HttpPost]
        public ActionResult Save(FormsViewModel viewModel)
        {
            context.DForm.Add(viewModel.DataForm);
            var dataCity = viewModel.ListofCity.Find(x => x.Id == viewModel.DataForm.City);

            context.SaveChanges();

            return RedirectToAction("SecondView", new { bookingId = viewModel.DataForm.Id, cityName = dataCity.Name });
        }

        public ActionResult SecondView(int bookingId, string cityName)
        {

            var result = context.DForm.Find(bookingId);
            result.NameC = cityName;
            var responseJsonService = GoToData(result.City);

            var dataImage = responseJsonService.weather;
            foreach (var item in dataImage)
            {
                iconID = item.icon;
                DescriptionCould = item.description;
            }

            var iconAddPath = "http://openweathermap.org/img/w/" + iconID + ".png";
            result.iconURL = iconAddPath;
            result.DescriptionforCloud = DescriptionCould;
            var up = context.DForm.Remove(result);
            context.SaveChanges();
            context.DForm.Add(result);
            context.SaveChanges();
            

            return View(result);
        }


        private ClimaCity GoToData(int city)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62412/");
                var response = client.GetAsync($"api/services/{city}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    dataClimaCity = JsonConvert.DeserializeObject<ClimaCity>(jsonString.Result);

                }
            }

            return dataClimaCity;
        }

        public ActionResult AllReservations()
        {
            var list = context.DForm.ToList();
            return View(list);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}