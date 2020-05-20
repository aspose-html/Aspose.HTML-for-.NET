using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Rendering.Image;
using Aspose.HTML.Live.Demos.UI.Helpers.Html;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	/// <summary>
	/// //
	/// </summary>
	public abstract class ExportHelper : IDisposable
	{

		private ExportFormat dstFormat_;
		private string srcPath_;

		//public ExportHelper(string sourcePath, ExportFormat dstFormat)
		//{
		//	dstFormat_ = dstFormat;
		//	srcPath_ = sourcePath;
		//}

		/// <summary>
		/// Constructor that specifies an export result format 
		/// </summary>
		/// <param name="dstFormat"></param>
		public ExportHelper(ExportFormat dstFormat)
		{
			dstFormat_ = dstFormat;
		}

		/// <summary>
		/// Get source file format by its name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static SourceFormat GetSourceFormatByFileName(string name)
		{
			var srcExt = Path.GetExtension(name).ToLowerInvariant();
			switch (srcExt)
			{
				case ".zip": return SourceFormat.ZIP;
				case ".htm":
				case ".html": return SourceFormat.HTML;
				case ".xhtml": return SourceFormat.XHTML;
				case ".epub": return SourceFormat.EPUB;
				case ".svg": return SourceFormat.SVG;
				case ".mhtml":
				case ".mht": return SourceFormat.MHTML;
				case ".md": return SourceFormat.MD;
				default: return SourceFormat.HTML;
			}
		}

		public static ExportHelper GetHelper(SourceFormat srcFormat, ExportFormat format, Dictionary<string, string> customParams = null)
		{
			ExportHelper helper = null;

			switch (srcFormat)
			{
				case SourceFormat.EPUB:
					helper = new ExportHelperEpub(format);
					break;
				case SourceFormat.MHTML:
					helper = new ExportHelperMhtml(format);
					break;
				case SourceFormat.SVG:
					helper = new ExportHelperSvg(format);
					break;
				case SourceFormat.MD:
					helper = new ExportHelperMarkdown(format);
					if(customParams != null && customParams.ContainsKey("cssTheme"))
					{
						((ExportHelperMarkdown)helper).CssTheme = customParams["cssTheme"];
					}
					break;
				case SourceFormat.HTML:
				case SourceFormat.XHTML:
				default:
					helper = new ExportHelperHtml(format);
					break;
			}
			return helper;
		}

		/// <summary>
		/// Render a file into specified device.
		/// </summary>
		/// <param name="sourcePath"></param>
		/// <param name="outDevice"></param> 
		protected abstract void Render(string sourcePath, IDevice outDevice);

		/// <summary>
		/// Render a number of files into specified device
		/// </summary>
		/// <param name="sourcePathList"></param>
		/// <param name="outDevice"></param>
		protected abstract void Render(string[] sourcePathList, IDevice outDevice);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sourcePathList"></param>
		/// <param name="outPath"></param>
		/// <param name="options"></param>
		public virtual void Export(string[] sourcePathList, string outPath, RenderingOptions options = null)
		{
			switch (dstFormat_)
			{
				case ExportFormat.PDF:
					PdfRenderingOptions pdf_opts = options as PdfRenderingOptions;
					if (pdf_opts == null)
						pdf_opts = new PdfRenderingOptions();

					using (PdfDevice device = new PdfDevice(pdf_opts, outPath))
					{
						if (sourcePathList.Length == 1)
							Render(sourcePathList[0], device);
						else
							Render(sourcePathList, device);
					}
					break;
				case ExportFormat.XPS:
					XpsRenderingOptions xps_opts = options as XpsRenderingOptions;
					if (xps_opts == null)
						xps_opts = new XpsRenderingOptions();

					using (XpsDevice device = new XpsDevice(xps_opts, outPath))
					{
						if (sourcePathList.Length == 1)
							Render(sourcePathList[0], device);
						else
							Render(sourcePathList, device);
					}
					break;
				case ExportFormat.MD:
						IDevice nullDev = null;
						Render(sourcePathList[0], nullDev);
					break;
				case ExportFormat.MHTML:
					throw new NotImplementedException("Conversion to 'MHTML' isn't implemented yet.");
				//break;
				case ExportFormat.JPEG:
				case ExportFormat.PNG:
				case ExportFormat.BMP:
				case ExportFormat.TIFF:
				case ExportFormat.GIF:
					ImageRenderingOptions img_opts = options as ImageRenderingOptions;
					if (img_opts == null)
						img_opts = new ImageRenderingOptions();
					switch (dstFormat_)
					{
						case ExportFormat.JPEG:
							img_opts.Format = ImageFormat.Jpeg; break;
						case ExportFormat.PNG:
							img_opts.Format = ImageFormat.Png; break;
						case ExportFormat.BMP:
							img_opts.Format = ImageFormat.Bmp; break;
						case ExportFormat.TIFF:
							img_opts.Format = ImageFormat.Tiff; break;
						case ExportFormat.GIF:
							img_opts.Format = ImageFormat.Gif; break;
					}
					using (ImageDevice device = new ImageDevice(img_opts, outPath))
					{
						if (sourcePathList.Length == 1)
							Render(sourcePathList[0], device);
						else
							Render(sourcePathList, device);
					}
					break;
			}

		}

		#region IDisposable
		private bool isDisposed = false;
		/// <summary>
		/// IDisposable.Dispose() implementation
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
				}
				isDisposed = true;
			}
		}

		#endregion
	}
}
