using System;
using System.IO;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Saving;
using Aspose.Html.Services;
using WebGrease.Css.Extensions;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion
{
	class MarkdownConversionHandler : ConversionHandler
	{
		public MarkdownConversionHandler(params ConversionHandlerFilter[] filters)
			: base(filters)
		{

		}

		protected override RenderingWorkUnit CreateWorkItem(DataSource source, Configuration configuration)
		{
			return new MarkdownDocumentRenderingWorkUnit(source.Uri, configuration);
		}

		protected override void Render(RenderingWorkUnit workUnit, ConversionApplicationOptions options, string outputFilePath)
		{
			var wi = ((MarkdownDocumentRenderingWorkUnit)workUnit);

			if (options.OutputFormat == FileFormat.HTML)
			{
				wi.Data.Save(outputFilePath, HTMLSaveFormat.HTML);
			}
			else
			{
				using (var renderer = new HtmlRenderer())
				using (var device = GetOutputDevice(options, outputFilePath))
				{
					renderer.Render(device, wi.Data, ConversionApplication.DEFAULT_RENDERING_TIMEOUT);
				}
			}
		}

		protected override void Render(RenderingWorkUnit[] workUnits, ConversionApplicationOptions options, string outputFilePath)
		{
			using (var renderer = new HtmlRenderer())
			using (var device = GetOutputDevice(options, outputFilePath))
			{
				renderer.Render(device, ConversionApplication.DEFAULT_RENDERING_TIMEOUT,
					workUnits.Cast<MarkdownDocumentRenderingWorkUnit>().Select(x => x.Data).ToArray());
			}
		}

		protected override Configuration GetConfiguration(ConversionApplicationOptions options)
		{
			var configuration = base.GetConfiguration(options);
			if (!string.IsNullOrEmpty(options.MarkdowTheme))
			{
				var filePath = System.Web.Hosting.HostingEnvironment.MapPath($"~/App_Data/MDThemes/{options.MarkdowTheme}.css");
				if (File.Exists(filePath))
				{
					configuration.GetService<IUserAgentService>().UserStyleSheet = File.ReadAllText(filePath);
				}
			}

			return configuration;
		}
	}
}
