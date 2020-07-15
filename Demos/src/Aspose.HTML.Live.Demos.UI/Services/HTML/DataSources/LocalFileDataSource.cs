using System.IO;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources
{
	class LocalFileDataSource : DataSource
	{
		public LocalFileDataSource(string filePath)
			: base(filePath)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (HTMLOperationContextScope.Context.DeleteSourceFolder)
			{
				if (File.Exists(Uri))
					System.IO.File.Delete(Uri);
			}
			base.Dispose(disposing);
		}
	}
}
