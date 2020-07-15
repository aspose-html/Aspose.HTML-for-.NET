using System;
using System.IO;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Saving;
using WebGrease.Css.Extensions;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion
{
	class SVGConversionHandler : ConversionHandler
	{
		public SVGConversionHandler(params ConversionHandlerFilter[] filters)
			: base(filters)
		{

		}

		protected override RenderingWorkUnit CreateWorkItem(DataSource source, Configuration configuration)
		{
			return new SVGDocumentRenderingWorkUnit(source.Uri, configuration);
		}

		protected override void Render(RenderingWorkUnit workUnit, ConversionApplicationOptions options, string outputFilePath)
		{
			var wi = ((SVGDocumentRenderingWorkUnit)workUnit);

			using (var renderer = new SvgRenderer())
			using (var device = GetOutputDevice(options, outputFilePath))
			{
				renderer.Render(device, wi.Data, ConversionApplication.DEFAULT_RENDERING_TIMEOUT);
			}
		}

		protected override void Render(RenderingWorkUnit[] workUnits, ConversionApplicationOptions options, string outputFilePath)
		{
			using (var renderer = new SvgRenderer())
			using (var device = GetOutputDevice(options, outputFilePath))
			{
				renderer.Render(device, ConversionApplication.DEFAULT_RENDERING_TIMEOUT,
					workUnits.Cast<SVGDocumentRenderingWorkUnit>().Select(x => x.Data).ToArray());
			}
		}
	}
}
