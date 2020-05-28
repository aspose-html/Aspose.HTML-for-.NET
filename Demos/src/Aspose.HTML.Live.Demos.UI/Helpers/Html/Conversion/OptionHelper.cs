using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Aspose.Html.Drawing;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	public static class OptionHelper
	{
		private static Dictionary<string, double[]> pageSizes;
		private static List<Tuple<string, string>> pageTitlesLst;
		static OptionHelper()
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

			pageTitlesLst = new List<Tuple<string, string>>()
			{
				new Tuple<string, string>("letter", "Letter"),
				new Tuple<string, string>("tabloid", "Tabloid"),
				new Tuple<string, string>("legal", "Legal"),
				new Tuple<string, string>("statement", "Statement"),
				new Tuple<string, string>("executive", "Executive"),
				new Tuple<string, string>("a3", "A3"),
				new Tuple<string, string>("a4", "A4"),
				new Tuple<string, string>("a5", "A5"),
				new Tuple<string, string>("b4", "B4 (JIS)"),
				new Tuple<string, string>("b5", "B5 (JIS)")
			};
			
		}

		public static List<Tuple<string, string>> getPageSizes()
		{
			return pageTitlesLst;
		}

		public static Size getPageSizeByName(string name)
		{
			Size res = null;
			if (pageSizes.ContainsKey(name))
			{
				double[] sz = pageSizes[name];
				res = new Size(Length.FromInches(sz[0]), Length.FromInches(sz[1]));
			}
			return res;
		}
	}
}
