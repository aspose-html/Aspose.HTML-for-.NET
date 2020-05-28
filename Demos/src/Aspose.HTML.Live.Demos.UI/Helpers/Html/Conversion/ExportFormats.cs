using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	/// <summary>
	/// HTML document export formats
	/// </summary>
	public enum ExportFormat
	{
		_None,
		PDF,
		XPS,
		JPEG,
		PNG,
		BMP,
		TIFF,
		GIF,
		MD,
		MHTML
	}
	public static class ExportFormats
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static bool IsSupportedFormatName(string formatName, out ExportFormat outFormat)
		{
			ExportFormat expFormat;
			if (!Enum.TryParse(formatName.ToUpper(), out expFormat))
			{
				//var key = formatName.ToLower();
				//if (!mapFormatAliases.ContainsKey(key))
				//{
				outFormat = ExportFormat._None;
				return false;
				//}

				//Enum.TryParse(mapFormatAliases[key].ToUpper(), out expFormat);
			}
			outFormat = expFormat;
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static bool IsImageFormat(ExportFormat format)
		{
			switch (format)
			{
				case ExportFormat.BMP:
				case ExportFormat.GIF:
				case ExportFormat.JPEG:
				case ExportFormat.PNG:
				case ExportFormat.TIFF:
					return true;
			}
			return false;
		}
	}
}
