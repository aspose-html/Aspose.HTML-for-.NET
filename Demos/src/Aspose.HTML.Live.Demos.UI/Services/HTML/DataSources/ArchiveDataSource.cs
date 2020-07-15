using System;
using System.IO;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources
{
	class ArchiveDataSource : DataSource
	{
		private bool isInitialized;
		private string archiveFilePath;
		private string filePath;

		public ArchiveDataSource(string filePath)
			: base(filePath)
		{
			this.archiveFilePath = filePath;
		}

		public override string Uri
		{
			get
			{
				if (!isInitialized)
				{
					isInitialized = true;

					var destination = Path.Combine(Path.GetDirectoryName(archiveFilePath), Path.GetFileNameWithoutExtension(archiveFilePath));
					if(Directory.Exists(destination))
						Directory.Delete(destination, true);
					System.IO.Compression.ZipFile.ExtractToDirectory(archiveFilePath, destination);

					var files = Directory.GetFiles(destination, "*.*", SearchOption.TopDirectoryOnly);

					// Try to find the 'index.<input-format>' file
					filePath = files.FirstOrDefault(x =>
						Path.GetFileName(x)
							.Equals(
								$"index{HTMLOperationContextScope.Context.InputFormat.ToFileExtension()}",
								StringComparison.OrdinalIgnoreCase));
					if (!string.IsNullOrEmpty(filePath))
						return filePath;

					// Get any file with the corresponded extension
					filePath = files.FirstOrDefault(x =>
						Path.GetExtension(x).Equals(
							HTMLOperationContextScope.Context.InputFormat.ToFileExtension(),
							StringComparison.OrdinalIgnoreCase));
					if (!string.IsNullOrEmpty(filePath))
						return filePath;
				}

				return filePath;
			}
		}

		public override bool IsValid()
		{
			return !string.IsNullOrEmpty(Uri);
		}

		protected override void Dispose(bool disposing)
		{
			if (HTMLOperationContextScope.Context.DeleteSourceFolder)
			{
				if(File.Exists(archiveFilePath))
					System.IO.File.Delete(archiveFilePath);

				var destination = Path.Combine(Path.GetDirectoryName(archiveFilePath), Path.GetFileNameWithoutExtension(archiveFilePath));
				if (Directory.Exists(destination))
					Directory.Delete(destination, true);
			}

			base.Dispose(disposing);
		}
	}
}
