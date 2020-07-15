using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.Html.Drawing;
using Size = Aspose.Html.Drawing.Size;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion
{
	public class ConversionApplicationOptions : ApplicationOptions
	{
		public const string OPTION_MERGE_MULTIPLE = "mergeMultiple";
		private const string OPTION_USER_PASSWORD = "userPassword";
		private const string OPTION_OWNER_PASSWORD = "ownerPassword";
		private const string OPTION_PAGE_SIZE = "pageSize";
		private const string OPTION_BG_COLOR = "bgColor";
		private const string OPTION_MD_THEME = "mdTheme";
		

		// inputType
		private static Dictionary<string, double[]> pageSizes;
		//private static List<Tuple<string, string>> pageTitlesLst;

		static ConversionApplicationOptions()
		{
			pageSizes = new Dictionary<string, double[]>() {
				{ "letter", new double[] { 8.5, 11.0 } },
				{ "tabloid", new double[] { 11.0, 17.0} },
				{ "legal", new double[] { 8.5, 14.0 } },
				{ "statement", new double[] { 5.5, 8.5 } },
				{ "executive", new double[] { 7.0, 10.0 } },
				{ "a3", new double[] { 11.7, 16.5 } },
				{ "a4", new double[] { 8.3, 11.7 } },
				{ "a5", new double[] { 5.8, 8.3 } },
				{ "b4", new double[] { 9.8, 13.9 } },
				{ "b5", new double[] { } }
			};

			//pageTitlesLst = new List<Tuple<string, string>>()
			//{
			//	new Tuple<string, string>("letter", "Letter"),
			//	new Tuple<string, string>("tabloid", "Tabloid"),
			//	new Tuple<string, string>("legal", "Legal"),
			//	new Tuple<string, string>("statement", "Statement"),
			//	new Tuple<string, string>("executive", "Executive"),
			//	new Tuple<string, string>("a3", "A3"),
			//	new Tuple<string, string>("a4", "A4"),
			//	new Tuple<string, string>("a5", "A5"),
			//	new Tuple<string, string>("b4", "B4 (JIS)"),
			//	new Tuple<string, string>("b5", "B5 (JIS)")
			//};
		}

		public ConversionApplicationOptions(FileFormat inputFormat, FileFormat outputFormat, bool merge, IDictionary<string, string> @params)
			: base(
				new Dictionary<string, string>()
				{
					{OPTION_INPUT_TYPE, inputFormat},
					{OPTION_OUTPUT_TYPE, outputFormat},
					{OPTION_MERGE_MULTIPLE, merge.ToString()},
				}.Merge(@params, key => key.ToUpper()))
		{
		}

		public ConversionApplicationOptions(FileFormat inputFormat, FileFormat outputFormat, bool merge)
			: this(inputFormat, outputFormat, merge, new Dictionary<string, string>())
		{ }

		public ConversionApplicationOptions(IDictionary<string, string> @params)
			: base(@params)
		{

		}

		public FileFormat InputFormat
		{
			get
			{
				var result = GetValueOrDefault<string>(OPTION_INPUT_TYPE);
				if (string.IsNullOrEmpty(result))
					return FileFormat.Unknown;
				return (FileFormat)result;
			}
		}

		public FileFormat OutputFormat
		{
			get
			{
				var result = GetValueOrDefault<string>(OPTION_OUTPUT_TYPE);
				if (string.IsNullOrEmpty(result))
					return FileFormat.Unknown;
				return (FileFormat)result;
			}
		}

		public bool Merge
		{
			get { return GetValueOrDefault<bool>(OPTION_MERGE_MULTIPLE); }
			set { SetValue(OPTION_MERGE_MULTIPLE, value); }
		}

		public string UserPassword
		{
			get { return GetValueOrDefault<string>(OPTION_USER_PASSWORD); }
		}

		public string OwnerPassword
		{
			get { return GetValueOrDefault<string>(OPTION_OWNER_PASSWORD); }
		}

		public Size PageSize
		{
			get
			{
				var pageSize = GetValueOrDefault<string>(OPTION_PAGE_SIZE);
				if (!string.IsNullOrEmpty(pageSize) && pageSizes.ContainsKey(pageSize))
				{
					double[] sz = pageSizes[pageSize];
					return new Size(Length.FromInches(sz[0]), Length.FromInches(sz[1]));
				}

				return default(Size);
			}
		}

		public Color BackgroundColor
		{
			get
			{
				var bgColor = GetValueOrDefault<string>(OPTION_BG_COLOR);
				if (!string.IsNullOrEmpty(bgColor) && int.TryParse(bgColor, System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int argb))
				{
					argb = (int) (argb | 0xFF000000);
					return Color.FromArgb(argb);
				}
				return Color.Transparent;
			}
		}

		public string MarkdowTheme
		{
			get { return GetValueOrDefault<string>(OPTION_MD_THEME); }
		}
	}
}
