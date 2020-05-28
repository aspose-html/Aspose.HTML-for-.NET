using System;
using System.ComponentModel.Design;
using System.Web;
using Aspose.HTML.Live.Demos.UI.Services.HTML;
using Aspose.Html.Rendering.Image;

namespace Aspose.HTML.Live.Demos.UI.Services.Extensions
{

	public static class FileFormatExtensions
	{

		public static string ToFileExtension(this FileFormat format)
		{
			if(FileFormat.JPEG == format)
				return $".jpg";
			return $".{format.Name.ToLower()}";
		}

		public static ImageFormat ToImageFormat(this FileFormat format)
		{
			if (FileFormat.JPEG == format)
				return ImageFormat.Jpeg;
			if (FileFormat.PNG == format)
				return ImageFormat.Png;
			if (FileFormat.BMP == format)
				return ImageFormat.Bmp;
			if (FileFormat.TIFF == format)
				return ImageFormat.Tiff;
			if (FileFormat.GIF == format)
				return ImageFormat.Gif;
			throw new ArgumentException($"The '{format}' can not be converted to the ImageFormat object.", "format");
		}
	}
}
