using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;
using Aspose.Html.Rendering;
using WebGrease.Css.Extensions;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	public class ExportHelperMarkdown : ExportHelper
	{
		public ExportHelperMarkdown(ExportFormat format) : base(format)
		{ }

		public string CssTheme { get; set; }

		protected override void Render(string sourcePath, IDevice device)
		{
			using (Configuration configuration = new Configuration())
			{
				var userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
				if (!string.IsNullOrEmpty(CssTheme))
				{
					var csspath = System.Web.Hosting.HostingEnvironment.MapPath($"~/App_Data/MDThemes/{CssTheme}.css");
					if (File.Exists(csspath))
					{
						userAgent.UserStyleSheet = File.ReadAllText(csspath);
					}
				}
				using (Aspose.Html.HTMLDocument document = Converter.ConvertMarkdown(sourcePath, configuration))
				{
					document.RenderTo(device);
				}
			}
		}
		
		protected override void Render(string[] sourcePathList, IDevice outDevice)
		{
			var units = new RenderingUnit[sourcePathList.Length];
			try
			{
				for (int i = 0; i < sourcePathList.Length; i++)
					units[i] = new RenderingUnit(sourcePathList[i], CssTheme);
				using (HtmlRenderer renderer = new HtmlRenderer())
				{
					renderer.Render(outDevice, units.Select(x => x.Document).ToArray());
				}

			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				units.ForEach(x => x?.Dispose());
			}
		}

		sealed class RenderingUnit : IDisposable
		{
			private readonly Configuration configuration;
			private readonly HTMLDocument document;

			public RenderingUnit(string sourcePath, string theme)
			{
				configuration = new Configuration();
				var userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
				if (!string.IsNullOrEmpty(theme))
				{
					var themeFilePath = System.Web.Hosting.HostingEnvironment.MapPath($"~/App_Data/MDThemes/{theme}.css");
					if (File.Exists(themeFilePath))
						userAgent.UserStyleSheet = File.ReadAllText(themeFilePath);
				}
				document = Converter.ConvertMarkdown(sourcePath, configuration);
			}

			public HTMLDocument Document => document;

			public void Dispose()
			{
				Document.Dispose();
				configuration.Dispose();
			}
		}
	}
}
