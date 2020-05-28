using Aspose.HTML.Live.Demos.UI.Models.Common;
using Aspose.HTML.Live.Demos.UI.Models;
using Aspose.HTML.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.HTML.Live.Demos.UI.Controllers
{
	public class MergerController : BaseController  
	{
		public override string Product => (string)RouteData.Values["product"];


		[HttpPost]
		public Response Merger(string outputType)
		{
			Response response = null;

			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var _docs = UploadFiles(Request, _sourceFolder);

				AsposeHtmlMerger _asposeHtmlMerger = new AsposeHtmlMerger();
				response = _asposeHtmlMerger.Merge(_docs, outputType);

			}

			return response;			
				
		}

		

		public ActionResult Merger()
		{
			var model = new ViewModel(this, "Merger")
			{
				SaveAsComponent = true,
				SaveAsOriginal = false,
				MaximumUploadFiles = 10,
				UseSorting = true,
				DropOrUploadFileLabel = Resources["DropOrUploadFiles"]
			};

			return View(model);
		}
		

	}
}
