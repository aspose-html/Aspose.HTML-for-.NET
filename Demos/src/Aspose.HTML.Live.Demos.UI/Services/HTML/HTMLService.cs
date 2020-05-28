using System;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Merger;
using ApplicationId = Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.ApplicationId;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	/// <summary>
	/// This class contains all business logic for HTML.Apps 
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public partial class HTMLService : IDisposable
	{
		public HTMLService()
		{
			FileNameProvider = new FileNameProvider();
		}

		public Result Convert(InputDataProvider inputData, ConversionApplicationOptions options)
		{
			return Execute(ApplicationRegistry.Instance.Get(ApplicationId.Conversion), inputData, options);
		}

		public Result Merge(InputDataProvider inputData, MergerApplicationOptions options)
		{
			if (inputData.GetData().Count(x => x.IsValid()) < 2)
				return Result.Error(ErrorCodes.NotEnoughFilesToPerformOperation);

			return Execute(ApplicationRegistry.Instance.Get(ApplicationId.Merger), inputData, options);
		}

		Result Execute(Application application, InputDataProvider inputData, ApplicationOptions options)
		{
			var result = application.Execute(inputData, options);
			if (result.IsValid &&
			    (result.DataFiles.Count > 1 && HTMLOperationContextScope.Context.PackIfResultHasMultipleFiles))
			{
				var fileName = Guid.NewGuid();
				var zipTmpFilePath = Path.Combine(HTMLOperationContextScope.Context.OutputFolder, $"./../{fileName}.zip");
				var zipFilePath = Path.Combine(HTMLOperationContextScope.Context.OutputFolder, $"{ConversionApplication.DEFAULT_NAME_FOR_COVERTED_SET_OF_FILES}.zip");

				// TODO: Use the result.DataFiles property instead of packing the whole output directory
				ZipFile.CreateFromDirectory(HTMLOperationContextScope.Context.OutputFolder, zipTmpFilePath);
				File.Move(zipTmpFilePath, zipFilePath);
				return Result.FromFiles(zipFilePath);
			}
			return result;
		}

		public IFileNameProvider FileNameProvider { get; }

		/// <summary>
		/// Releases all resources used by this object.
		/// </summary>
		public void Dispose()
		{
			// intentionally blank
		}
	}
}
