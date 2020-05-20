using Aspose.HTML.Live.Demos.UI.Models.Common;
using Aspose.HTML.Live.Demos.UI.Models;
using Aspose.HTML.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.HTML.Live.Demos.UI.Controllers
{
	public class ConversionController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];
		
		[HttpPost]
		public Response Conversion(string outputType)
		{
			Response response = null;
			
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var _docs = UploadFiles(Request, _sourceFolder);

				AsposeHtmlConversion _asposeHtmlConversion = new AsposeHtmlConversion();
				response = _asposeHtmlConversion.Convert(_docs,  _sourceFolder, outputType);

			}

			return response;

		}

		

		public ActionResult Conversion()
		{
			var model = new ViewModel(this, "Conversion")
			{
				SaveAsComponent = true,
				SaveAsOriginal = false,
				MaximumUploadFiles = 1,
				DropOrUploadFileLabel = Resources["DropOrUploadFile"]
			};

			return View(model);
		}
		

	}
}
