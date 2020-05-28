using Aspose.Html.Rendering.Image;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web.Http;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Models.Common;
using Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion;
using Aspose.HTML.Live.Demos.UI.Helpers.Html;

namespace Aspose.HTML.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeHtmlConversionController class to convert HTML files to different formats
	///</Summary>
public class AsposeHtmlConversion : AsposeHTMLBase
{
		private static List<string> imageTypes = new List<string>(){
			"jpeg", "jpg", "png", "gif", "bmp", "tif", "tiff"
		};
		private static string[] mergeableTypes = new string[] { "pdf", "xps", "tif", "tiff" };
		public AsposeHtmlConversion() : base()
		{
		}

		static AsposeHtmlConversion()
		{
		}

		///<Summary>
		/// Convert method - NEW
		///</Summary>
		
		public Response Convert(InputFiles docs, string sourceFolder,  string outputType)
		{
			
			  if (docs == null)
				return BadDocumentResponse;
			if (docs.Count == 0 || docs.Count > MaximumUploadFiles)
				return MaximumFileLimitsResponse;

			Opts.AppName = "ConversionApp";
			Opts.MethodName = "Convert";
			Opts.OutputType = outputType;
			//SetupQueryParameters(Opts.OutputType);
			Opts.ZipFileName = docs.Count == 1 ? Path.GetFileNameWithoutExtension(docs[0].FileName) : "Converted_Documents";
			SetDefaultOptions(docs, outputType);
			Opts.ResultFileName = Opts.ZipFileName;
			Opts.FolderName = sourceFolder;

			List<string> FileNames = new List<string>();
			

			foreach (InputFile inputFile in docs)
			{
				FileNames.Add(inputFile.LocalFileName);
			}
			return  Process((inFilePath, outPath, zipOutFolder) => {
				return ConvertFiles(FileNames.ToArray(), Opts.FolderName, Opts.OutputType);
			});
		} 

		private void SetupQueryParameters(string outputType)
		{
			Opts.SetupCustomQueryParameters(Request);
			string opt = "";
			Opts.MergeMultiple = false;
			if (mergeableTypes.Contains(outputType.ToLower().Replace(".", "")))
			{
				if ((opt = Opts.GetCustomParameter("mergeMultiple")) != null)
				{
					bool bMerge;
					if (bool.TryParse(opt, out bMerge))
						Opts.MergeMultiple = bMerge;
				}
			}
		}

		///<Summary>
		/// ConvertHtmlToPdf to convert html file to pdf
		///</Summary>
		public Response ConvertHtmlToPdf(string[] fileNames, string folderName)
        {
			return  ProcessTask_(fileNames, (inFiles, outPath, zipOutFolder) =>
			{
				Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdf_options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
				if(Opts.HasCustomParameter("ownerPassword") || Opts.HasCustomParameter("userPassword"))
				{
					var userPw = Opts.GetCustomParameter("userPassword");
					var ownerPw = Opts.GetCustomParameter("ownerPassword");
					if (!(string.IsNullOrEmpty(userPw) && string.IsNullOrEmpty(ownerPw)))
					{
						pdf_options.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
							userPw,
							ownerPw,
							(Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions)0xF3C,
							Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128
							);
					}
				}
				Dictionary<string, string> customParams = null;
				if (Opts.HasCustomParameter("mdTheme"))
				{
					var csstheme = Opts.GetCustomParameter("mdTheme");
					customParams = new Dictionary<string, string> { { "cssTheme", csstheme } };
				}
				SourceFormat srcFormat = ExportHelper.GetSourceFormatByFileName(Opts.FileName);
				ExportHelper helper = ExportHelper.GetHelper(srcFormat, ExportFormat.PDF, customParams);
				helper.Export(inFiles, outPath, pdf_options);   
			});
        }

		///<Summary>
		/// ConvertHtmlToXps to convert html file to xps
		///</Summary>
		public Response ConvertHtmlToXps(string[] fileNames, string folderName)
        {
			return  ProcessTask_(fileNames, (inFiles, outPath, zipOutFolder) =>
			{
				Aspose.Html.Rendering.Xps.XpsRenderingOptions xps_options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
				if (Opts.HasCustomParameter("pageSize"))
				{
					var sz = OptionHelper.getPageSizeByName(Opts.GetCustomParameter("pageSize"));
					if (sz != null)
					{
						xps_options.PageSetup.AnyPage.Size = sz;
					}
				}
				Dictionary<string, string> customParams = null;
				if (Opts.HasCustomParameter("mdTheme"))
				{
					var csstheme = Opts.GetCustomParameter("mdTheme");
					customParams = new Dictionary<string, string> { { "cssTheme", csstheme } };
				}
				SourceFormat srcFormat = ExportHelper.GetSourceFormatByFileName(Opts.FileName);
				ExportHelper helper = ExportHelper.GetHelper(srcFormat, ExportFormat.XPS, customParams);

				helper.Export(inFiles, outPath, xps_options);
            });
        }
		///<Summary>
		/// ConvertHtmlToMhtml to convert html file to mhtml
		///</Summary>
		public Response ConvertHtmlToMhtml(string[] fileNames, string folderName)
        {
            return  ProcessTask((inFilePath, outPath, zipOutFolder) =>
			{
				string fileName = fileNames[0];
				Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(fileName);
                document.Save(outPath, Html.Saving.HTMLSaveFormat.MHTML);
            });
        }
		///<Summary>
		/// ConvertHtmlToMarkdown to convert html file to Markdown
		///</Summary>
		public Response ConvertHtmlToMarkdown(string[] fileNames, string folderName)
        {
            return  ProcessTask((inFilePath, outPath, zipOutFolder) =>
			{
				string fileName = fileNames[0];
				//string fileName = inFilePath[0];
				Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(fileName);
                document.Save(outPath, Html.Saving.HTMLSaveFormat.Markdown);
            });
        }

		///<Summary>
		/// Convert Markdown to HTML
		///</Summary>
		public Response ConvertMarkdownToHtml(string[] fileNames, string folderName, string outputType)
        {
			Opts.OutputType = outputType;
			Opts.FolderName = folderName;
			Opts.FileNames = fileNames;

			return  ProcessTask((inFilePath, outPath, zipOutFolder) =>
			{
				//string fileName = fileNames[0];
				string fileName = inFilePath;
				var document = Aspose.Html.Converters.Converter.ConvertMarkdown(fileName);					
				document.Save(outPath);
			});
		}

		public Response ConvertMarkdownToHtml_(string[] fileNames, string folderName, string outputType)
		{
			Opts.OutputType = outputType;
			Opts.FolderName = folderName;

			return  ProcessTask_(fileNames, (inFiles, outPath, zipOutFolder) =>
			{
				string fileName = inFiles[0];
				var document = Aspose.Html.Converters.Converter.ConvertMarkdown(fileName);
				document.Save(outPath);
			});
		}

		///<Summary>
		/// ConvertHtmlToTiff to convert html file to tiff
		///</Summary>
		public Response ConvertHtmlToTiff(string[] fileNames, string folderName)
        {
			return  ProcessTask_(fileNames, (inFiles, outPath, zipOutFolder) =>
			{
				ImageRenderingOptions img_options = new ImageRenderingOptions();
				img_options.Format = ImageFormat.Tiff;
				if (Opts.HasCustomParameter("pageSize"))
				{
					var sz = OptionHelper.getPageSizeByName(Opts.GetCustomParameter("pageSize"));
					if (sz != null)
					{
						img_options.PageSetup.AnyPage.Size = sz;
					}

				}
				if (Opts.HasCustomParameter("bgColor"))
				{
					string bgColor = Opts.GetCustomParameter("bgColor");
					if(!string.IsNullOrEmpty(bgColor))
					{
						long argb = long.Parse(bgColor, System.Globalization.NumberStyles.HexNumber);
						img_options.BackgroundColor = System.Drawing.Color.FromArgb((int)(argb | 0xFF000000));
					}
				}
				Dictionary<string, string> customParams = null;
				if (Opts.HasCustomParameter("mdTheme"))
				{
					var csstheme = Opts.GetCustomParameter("mdTheme");
					customParams = new Dictionary<string, string> { { "cssTheme", csstheme } };
				}
				SourceFormat srcFormat = ExportHelper.GetSourceFormatByFileName(Opts.FileName);
				ExportHelper helper = ExportHelper.GetHelper(srcFormat, ExportFormat.TIFF, customParams);
				helper.Export(inFiles, outPath, img_options);
            });                   
        }

		///<Summary>
		/// ConvertHtmlToImages to convert html file to images
		///</Summary>
		public Response ConvertHtmlToImages(string[] fileNames, string folderName, string outputType)
        {
            if (outputType.Equals("bmp")
				|| outputType.Equals("jpg") || outputType.Equals("jpeg")
				|| outputType.Equals("png") || outputType.Equals("gif"))
            {
				ImageFormat format = ImageFormat.Bmp;
				ExportFormat expFormat = ExportFormat.BMP;

				if (outputType.Equals("jpg") || outputType.Equals("jpeg"))
				{
					format = ImageFormat.Jpeg;
					expFormat = ExportFormat.JPEG;
				}
				else if (outputType.Equals("png"))
				{
					format = ImageFormat.Png;
					expFormat = ExportFormat.PNG;
				}
				else if (outputType.Equals("gif"))
				{
					format = ImageFormat.Gif;
					expFormat = ExportFormat.GIF;
				}

				return  ProcessTask_(fileNames, (inFiles, outPath, zipOutFolder) =>
				{
					ImageRenderingOptions img_options = new ImageRenderingOptions();
					img_options.Format = format;
					if (Opts.HasCustomParameter("pageSize"))
					{
						var sz = OptionHelper.getPageSizeByName(Opts.GetCustomParameter("pageSize"));
						if (sz != null)
						{
							img_options.PageSetup.AnyPage.Size = sz;
						}
					}
					if (Opts.HasCustomParameter("bgColor"))
					{
						string bgColor = Opts.GetCustomParameter("bgColor");
						if (!string.IsNullOrEmpty(bgColor))
						{
							int argb = int.Parse(bgColor, System.Globalization.NumberStyles.HexNumber);
							img_options.BackgroundColor = System.Drawing.Color.FromArgb(argb);
						}
					}
					Dictionary<string, string> customParams = null;
					if (Opts.HasCustomParameter("mdTheme"))
					{
						var csstheme = Opts.GetCustomParameter("mdTheme");
						customParams = new Dictionary<string, string> { { "cssTheme", csstheme } };
					}
					SourceFormat srcFormat = ExportHelper.GetSourceFormatByFileName(Opts.FileName);
					ExportHelper helper = ExportHelper.GetHelper(srcFormat, expFormat, customParams);

					helper.Export(inFiles, outPath, img_options);
				});
            }

            return new Response
            {
                FileName = null,
                Status = "Output type not found",
                StatusCode = 500
            };
        }

		///<Summary>
		/// ConvertFile
		///</Summary>
		public Response ConvertFile(string fileName, string folderName, string outputType)
        {
            if (System.IO.Path.GetExtension(fileName).ToLower() == ".zip")
            {
                ProcessZipArchiveFile(ref fileName, folderName);
				folderName = Path.GetDirectoryName(fileName);
			}

            outputType = outputType.ToLower().Replace(".", "").Replace(" ", "");
			var fn = new string[] { fileName };

            if (outputType.StartsWith("pdf"))
            {
                return  ConvertHtmlToPdf(fn, folderName);
            }
            else if (outputType.Equals("mhtml"))
            {
                return  ConvertHtmlToMhtml(fn, folderName);
            }
            else if (outputType.Equals("tiff") || outputType.Equals("tif"))
            {
                return  ConvertHtmlToTiff(fn, folderName);
            }
            else if (imageTypes.Contains(outputType))
            {
                return  ConvertHtmlToImages(fn, folderName, outputType);
            }
            else if (outputType.Equals("md"))
            {
                return  ConvertHtmlToMarkdown(fn, folderName);
            }
            else if (outputType.Equals("xps"))
            {
                return  ConvertHtmlToXps(fn, folderName);
            }
			else if(outputType.Equals("html"))
			{
				return  ConvertMarkdownToHtml(fn, folderName, "html");
			}

            return new Response
            {
                FileName = null,
                Status = "Output type not found",
                StatusCode = 500
            };
        }


		public Response ConvertFiles(string[] fileNames, string folderName, string outputType)
		{
			if (fileNames.Length == 1)
				return  ConvertFile(fileNames[0], folderName, outputType);

			outputType = outputType.ToLower().Replace(".", "").Replace(" ", "");

			if (fileNames.Count(s => ".zip".Equals(Path.GetExtension(s).ToLower())) >= 1)
			{
				List<string> fileNames1 = new List<string>();
				string unzipFolderName;
				foreach (var fname in fileNames)
				{
					if (Path.GetExtension(fname).ToLower() == ".zip")
					{
						var fileName = fname;
						unzipFolderName = Path.Combine(folderName, $"{fname}__unzip");
						ProcessZipArchiveFile(ref fileName, unzipFolderName);
						fileNames1.Add(fileName);
					}
					else
						fileNames1.Add(fname);
				}
				fileNames = fileNames1.ToArray();
			}

			switch (outputType)
			{
				case "pdf":
					return  ConvertHtmlToPdf(fileNames, folderName);
				case "xps":
					return  ConvertHtmlToXps(fileNames, folderName);
				case "tiff":
				case "tif":
					return  ConvertHtmlToTiff(fileNames, folderName);
				case "md":
					return  ConvertHtmlToMarkdown(fileNames, folderName);
				case "html":
					return  ConvertMarkdownToHtml_(fileNames, folderName, "html");
				default:
					if(imageTypes.Contains(outputType))
					{
						return  ConvertHtmlToImages(fileNames, folderName, outputType);
					}
					break;
			}
			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}
		
	}
}
