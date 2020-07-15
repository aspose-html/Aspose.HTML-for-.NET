namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public class ConversionOptions
	{

		public ConversionOptions(FileFormat inputFormat, FileFormat outputFormat, bool merge)
		{
			this.InputFormat = inputFormat;
			this.OutputFormat = outputFormat;
			this.Merge = merge;
		}

		public FileFormat InputFormat { get; }
		public FileFormat OutputFormat { get; }
		public bool Merge { get; }
	}
}
