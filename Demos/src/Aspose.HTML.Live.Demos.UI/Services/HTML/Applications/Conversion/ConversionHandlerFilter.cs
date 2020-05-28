namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion
{
	class ConversionHandlerFilter : ExecutionHandlerFilter<ConversionApplicationOptions>
	{

		private readonly FileFormat inputFormat;
		private readonly FileFormat outputFormat;
		private readonly bool allowMerging;


		public ConversionHandlerFilter(FileFormat inputFormat, FileFormat outputFormat)
			: this(inputFormat, outputFormat, false)
		{

		}

		public ConversionHandlerFilter(FileFormat inputFormat, FileFormat outputFormat, bool allowMerging)
		{
			this.inputFormat = inputFormat;
			this.outputFormat = outputFormat;
			this.allowMerging = allowMerging;
		}

		public override MatchResult Match(ConversionApplicationOptions options)
		{
			if (options.InputFormat != inputFormat)
				return MatchResult.Error(ErrorCodes.InvalidInputFormat);

			if (options.OutputFormat != outputFormat)
				return MatchResult.Error(ErrorCodes.InvalidOutputFormat);

			if (options.Merge && !allowMerging)
				return MatchResult.Error(ErrorCodes.MergingIsNotAllowed);

			return MatchResult.True;
		}

		public override string ToString()
		{
			return allowMerging
					? $"{inputFormat} > {outputFormat}, merging"
					: $"{inputFormat} > {outputFormat}";
		}
	}
}
