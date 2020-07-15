using System;
using System.Collections.Generic;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Merger
{
	public class MergerApplicationOptions : ConversionApplicationOptions
	{
		private const string OPTION_SVG_POSSITION = "append";

		public MergerApplicationOptions(FileFormat inputFormat, FileFormat outputFormat, IDictionary<string, string> @params)
			: base(inputFormat, outputFormat, true, @params)
		{
		}

		public MergerApplicationOptions(FileFormat inputFormat, FileFormat outputFormat)
			: base(inputFormat, outputFormat, true)
		{ }

		public MergerApplicationOptions(IDictionary<string, string> @params)
			: base(@params)
		{
			this.Merge = true;
		}

		public bool MergeSVGAsVertically
		{

			get
			{
				var possition = GetValueOrDefault<string>(OPTION_SVG_POSSITION);
				return !("h".Equals(possition, StringComparison.OrdinalIgnoreCase) ||
				         "horizontal".Equals(possition, StringComparison.OrdinalIgnoreCase));
			}
		}
		
	}
}
