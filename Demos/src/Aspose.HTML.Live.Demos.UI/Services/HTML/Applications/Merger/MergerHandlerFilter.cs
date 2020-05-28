namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Merger
{
	class MergerHandlerFilter : ExecutionHandlerFilter<MergerApplicationOptions>
	{
		private readonly FileFormat inputFormat;
		private readonly FileFormat outputFormat;

		public MergerHandlerFilter(FileFormat inputFormat, FileFormat outputFormat)
		{
			this.inputFormat = inputFormat;
			this.outputFormat = outputFormat;
		}

		public override MatchResult Match(MergerApplicationOptions options)
		{
			if (options.InputFormat != inputFormat)
				return MatchResult.Error(ErrorCodes.InvalidInputFormat);

			if (options.OutputFormat != outputFormat)
				return MatchResult.Error(ErrorCodes.InvalidOutputFormat);

			return MatchResult.True;
		}

		public override string ToString()
		{
			return $"{inputFormat} > {outputFormat}";
		}
	}
}
