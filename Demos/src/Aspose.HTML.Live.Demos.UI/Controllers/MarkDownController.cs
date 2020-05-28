using Aspose.HTML.Live.Demos.UI.Models.Common;
using Aspose.HTML.Live.Demos.UI.Models;
using Aspose.HTML.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Aspose.HTML.Live.Demos.UI.Controllers
{
	public class MarkDownController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];
		
		

		

		public ActionResult MarkDown()
		{
			var model = new ViewModel(this, "MarkDown")
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
