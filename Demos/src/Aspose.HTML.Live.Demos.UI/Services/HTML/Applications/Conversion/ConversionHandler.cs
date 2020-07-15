using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Saving;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion
{
	abstract class ConversionHandler : ApplicationExecutionHandler<ConversionApplicationOptions>
	{
		protected ConversionHandler(params ExecutionHandlerFilter[] filters)
		{
		}
		
		public override Result Execute(InputDataProvider data, ConversionApplicationOptions options)
		{
			if (options.Merge && data.GetData().Count(x => x.IsValid()) > 1)
				return MergeFiles(data, options);

			return ConvertFiles(data, options);
		}

		protected abstract RenderingWorkUnit CreateWorkItem(DataSource source, Configuration configuration);

		protected abstract void Render(RenderingWorkUnit workUnit, ConversionApplicationOptions options, string outputFilePath);

		protected abstract void Render(RenderingWorkUnit[] workUnits, ConversionApplicationOptions options, string outputFilePath);

		protected virtual Result ConvertFiles(InputDataProvider data, ConversionApplicationOptions options)
		{
			try
			{
				foreach (var dataSource in data.GetData().Where(x => x.IsValid()))
				{
					var outputFilePath = Path.Combine(
						HTMLOperationContextScope.Context.OutputFolder,
						HTMLOperationContextScope.Context.Service.FileNameProvider
							.GetNextFileName(dataSource.Name, options.OutputFormat.ToFileExtension()));

					using (var configuration = GetConfiguration(options))
					using (var wu = CreateWorkItem(dataSource, configuration))
					{
						Render(wu, options, outputFilePath);
					}
				}

				return Result.FromDirectory(HTMLOperationContextScope.Context.OutputFolder);
			}
			catch (Exception e)
			{
				return Result.Error(e);
			}

		}

		protected virtual Result MergeFiles(InputDataProvider data, ConversionApplicationOptions options)
		{
			using (var configuration = GetConfiguration(options))
			{
				var units = Enumerable.Empty<RenderingWorkUnit>();
				try
				{
					units = data.GetData()
						.Where(x => x.IsValid())
						.Select(x => CreateWorkItem(x, configuration))
						.ToArray();

					var outputFilePath = Path.Combine(
						HTMLOperationContextScope.Context.OutputFolder,
						HTMLOperationContextScope.Context.Service.FileNameProvider
							.GetNextFileName(ConversionApplication.DEFAULT_NAME_FOR_MERGED_SET_OF_FILES,
								options.OutputFormat.ToFileExtension()));

					Render(units.Select(x => x).ToArray(), options, outputFilePath);

					return Result.FromFiles(outputFilePath);
				}
				catch (Exception e)
				{
					return Result.Error(e);
				}
				finally
				{
					units.ForEach(x => x?.Dispose());
				}
			}
		}

		protected static IDevice GetOutputDevice(ConversionApplicationOptions options, string filePath)
		{
			T ApplyPageSizeIfAny<T>(T renderingOptions)
				where T : RenderingOptions
			{
				if (options.PageSize != null)
					renderingOptions.PageSetup.AnyPage.Size = options.PageSize;
				return renderingOptions;
			}

			if (FileFormat.PDF == options.OutputFormat)
			{
				var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
				if (!string.IsNullOrEmpty(options.UserPassword) && !string.IsNullOrEmpty(options.OwnerPassword))
				{
					const PdfPermissions allPermissions = PdfPermissions.PrintDocument | PdfPermissions.ModifyContent |
					                           PdfPermissions.ExtractContent | PdfPermissions.ModifyTextAnnotations |
					                           PdfPermissions.FillForm | PdfPermissions.ExtractContentWithDisabilities |
					                           PdfPermissions.AssembleDocument | PdfPermissions.PrintingQuality;

					pdfOptions.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
						options.UserPassword,
						options.OwnerPassword,
						allPermissions,
						PdfEncryptionAlgorithm.RC4_128);
				}
				pdfOptions.BackgroundColor = options.BackgroundColor;
				return new PdfDevice(pdfOptions, filePath);
			}

			if (FileFormat.XPS == options.OutputFormat)
			{
				var xpsOptions = new XpsRenderingOptions();
				xpsOptions = ApplyPageSizeIfAny(xpsOptions);
				return new XpsDevice(ApplyPageSizeIfAny(xpsOptions), filePath);
			}


			if (FileFormat.JPEG == options.OutputFormat ||
			    FileFormat.PNG == options.OutputFormat ||
			    FileFormat.BMP == options.OutputFormat ||
			    FileFormat.TIFF == options.OutputFormat ||
			    FileFormat.GIF == options.OutputFormat)
			{
				var imageOptions = new ImageRenderingOptions(options.OutputFormat.ToImageFormat());
				imageOptions.BackgroundColor = options.BackgroundColor;
				imageOptions = ApplyPageSizeIfAny(imageOptions);
				return new ImageDevice(imageOptions, filePath);
			}
				

			throw new ArgumentException("The output format is not supported.", "OutputFormat");
		}
	}
}
