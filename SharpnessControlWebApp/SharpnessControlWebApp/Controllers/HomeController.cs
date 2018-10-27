using IdentitySample.Models;
using SharpnessControlWebApp.Extras;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {

        

        [HttpGet]
        public ActionResult Index()
        {
            //var test = new SharpnessPdfReport();
            //test.generateSharpnessTestReport();
            var dateFinnish = DateTime.Now.AddDays(20);
            var random = new Random();
            var context = new ApplicationDbContext();

            for (int i = 1; i < 320; i++)
            {
                dateFinnish = dateFinnish.AddDays(-1);
                //Console.WriteLine(dateFinnish.ToString() + " " + random.Next(4, 8).ToString());
            }


            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
