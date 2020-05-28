using Aspose.HTML.Live.Demos.UI.Config;
using Aspose.HTML.Live.Demos.UI.Models;
using Aspose.HTML.Live.Demos.UI.Services;
using Aspose.HTML.Live.Demos.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Aspose.HTML.Live.Demos.UI.Models.Common;
using System.IO;

namespace Aspose.HTML.Live.Demos.UI.Controllers
{
	public abstract class BaseController : Controller
	{
		/// <summary>
		/// Prepare upload files and return as documents
		/// </summary>
		/// <param name="inputType"></param>
		protected InputFiles UploadFiles(HttpRequestBase Request, string sourceFolder)
		{
			try
			{
				
				var pathProcessor = new PathProcessor(sourceFolder);
				InputFiles documents = new InputFiles();

				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _fileName = postedFile.FileName;
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(_fileName);
							postedFile.SaveAs(_savepath);
							documents.Add(new InputFile(_fileName, sourceFolder, _savepath));
						}
					}
				}
				return documents;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;

			}
		}
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};
		

		public abstract string Product { get; }

		protected override void OnActionExecuted(ActionExecutedContext ctx)
		{
			base.OnActionExecuted(ctx);			
			ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
			ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
		}
		
		private AsposeHTMLContext _atcContext;
		

		/// <summary>
		/// Main context object to access all the dcContent specific context info
		/// </summary>
		public AsposeHTMLContext AsposeHTMLContext
		{
			get
			{
				if (_atcContext == null) _atcContext = new AsposeHTMLContext(HttpContext.ApplicationInstance.Context);
				return _atcContext;
			}
		}

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposeHTMLContext.Resources;
				return _resources;
			}
		}

		

		
	}
}
