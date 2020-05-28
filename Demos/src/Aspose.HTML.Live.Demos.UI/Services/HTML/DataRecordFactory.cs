using System;
using System.IO;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.DataSources;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public class DataRecordFactory
	{
		public DataSource CreateDataSource(string filePath)
		{
			var ext = Path.GetExtension(filePath);
			if(FileFormat.ZIP.ToFileExtension().Equals(ext, StringComparison.OrdinalIgnoreCase))
				return new ArchiveDataSource(filePath);
			return new LocalFileDataSource(filePath);
		}
	}
}
