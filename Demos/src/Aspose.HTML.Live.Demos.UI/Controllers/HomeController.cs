using Aspose.HTML.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.HTML.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Free Apps, On Premise &amp; Cloud APIs for HTML files manipulation";
			ViewBag.MetaDescription = "Read HTML EPUB or MHTML. Edit or render to PDF, Image, Markdown, MHTML. Merge HTML, EPUB or extract text &amp; images from HTML, XHTML, MHTML, EPUB, SVG files.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
