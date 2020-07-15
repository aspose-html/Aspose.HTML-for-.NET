using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Aspose.HTML.Live.Demos.UI.Models.Common;
using Aspose.HTML.Live.Demos.UI.Models;
using Aspose.HTML.Live.Demos.UI.Helpers.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Dom.Svg;
using Aspose.HTML.Live.Demos.UI.Services;
using Aspose.HTML.Live.Demos.UI.Services.HTML;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Models
{
	/// <summary>
	/// AsposeHtmlMerger class to merge HTML, MHTML, SVG, EPUB files and save to different formats
	/// </summary>
	public class AsposeHtmlMerger : AsposeHTMLBase
	{
		///<Summary>, 
		/// Convert method - NEW
		///</Summary>
		[MimeMultipart]
		[HttpPost]
		[ActionName("Merge")]
		public Response Merge( InputFiles files, string outputType)
		{
			
			try
			{
				List<string> FileNames = new List<string>();


				foreach (InputFile inputFile in files)
				{
					FileNames.Add(inputFile.LocalFileName);
				}
				
				using (var service = new HTMLService())
				using (new HTMLOperationContextScope(service, new HttpRequestMessage()))
				using (var dataProvider = new UrlDataProvider(FileNames.ToArray()))
				{
					var data = dataProvider.GetData();
					if (data.Count(x => x.IsValid()) == 0)
						return BadDocumentResponse;

					if (data.Count(x => x.IsValid()) > MaximumUploadFiles)
						return MaximumFileLimitsResponse;

					// HTMLOperationContextScope.Context.DeleteSourceFolder = true;

					var options = HTMLOperationContextScope
						.Context
						.ApplicationOptionsFactory
						.CreateMergerOptions();

					var result = service.Merge(dataProvider, options);

					if (!result.IsValid)
					{
						string message;
						switch (result.ErrorCode)
						{
							case ErrorCodes.InvalidInputFormat:
								message = $"Input type '{options.InputFormat}' is not supported.";
								break;
							case ErrorCodes.InvalidOutputFormat:
								message = $"Output type '{options.InputFormat}' is not supported.";
								break;
							case ErrorCodes.MergingIsNotAllowed:
								message =  $"Document merging is not supported for the '{options.OutputFormat}' format.";
								break;
							case ErrorCodes.NotEnoughFilesToPerformOperation:
								message = "Merging is required more than one input file.";
								break;
							case ErrorCodes.SystemException:
								

								message = $"Document processing error.";
								break;
							case ErrorCodes.DocumentLoadError:
							case ErrorCodes.DocumentRenderingError:
							default:
								message = $"Document processing error.";
								break;
						}

						return new Response
						{
							FileName = null,
							Status = message,
							StatusCode = 500
						};
					}

					

					return new Response
					{
						FileName = Path.GetFileName(result.DataFiles.First()),
						FolderName = $"{HTMLOperationContextScope.Context.Id}",
						Status = "OK",
						StatusCode = 200,
					};

				}
			}
			catch (Exception e)
			{
				

				return new Response
				{
					FileName = null,
					Status = $"Document processing error.",
					StatusCode = 500
				};
			}
		}
	}
}
