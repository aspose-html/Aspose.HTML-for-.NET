using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleChartDemo.Charts;

namespace SimpleChartDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SimpleChartDemo is an application to demonstrate SVG features of Aspose.HTML.";
            return View();
        }
        public ActionResult ChartDemo()
        {
            const string contentType = "image/svg+xml; charset=utf-8";
            var elements = new List<ChartElement>
            {
                new ChartElement("Chongqing", 30165.500f),
                new ChartElement("Shanghai", 24183.300f),
                new ChartElement("Beijing", 21707.000f),
                new ChartElement("Istanbul", 15029.231f),
                new ChartElement("Karachi", 14910.352f),
                new ChartElement("Dhaka", 14399.000f),
                new ChartElement("Guangzhou", 13081.000f),
                new ChartElement("Shenzhen", 12528.300f),
                new ChartElement("Mumbai", 12442.373f),
                new ChartElement("Moscow", 13200.000f)
            };
            var chart = new Chart(elements, 400, 600)
            {
                LabelCount = 5,
                Margin = 20
            };
            return Content(chart.Render(), contentType);
        }
}
}