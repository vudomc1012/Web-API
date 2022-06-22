using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace WEBAPI.Controllers
{
    public class PeopleController : Controller
    {
        //Get people
        public IActionResult Index()
        {
            string path = "https://randomuser.me/api/?results=15";
            object people = GetPeople(path);
            JObject jObject = JObject.Parse(people.ToString());
            ViewBag.data = jObject["results"];
            return View();
        }

        public object GetPeople(string path)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<Object>(
                    webClient.DownloadString(path)
            );
            }
        }
    }
}
