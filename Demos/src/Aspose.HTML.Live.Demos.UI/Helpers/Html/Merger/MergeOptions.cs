
namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Merger
{
	public sealed class MergeOptions
	{

		#region Fields

		private static MergeOptions empty = new MergeOptions();

		#endregion

		#region Properties

		/// <summary>
		/// Border flag. Default - false.
		/// </summary>
		public bool IsBordered { get; set; } = false;

		/// <summary>
		/// Separator flag. Default - false.
		/// </summary>
		public bool IsWithSeparator { get; set; } = false;

		/// <summary>
		/// Border line color. Default - "orange".
		/// </summary>
		public string BorderColor { get; set; } = "orange";

		/// <summary>
		/// Separator line color. Default - "orange".
		/// </summary>
		public string SeparatorColor { get; set; } = "orange";

		/// <summary>
		/// Border stroke width. Default - 5f.
		/// </summary>
		public double BorderStroke { get; set; } = 5f;

		/// <summary>
		/// Separator stroke width. Default - 5f.
		/// </summary>
		public double SeparatorStroke { get; set; } = 5f;

		/// <summary>
		/// Default options instance: non bordered and not stroked 
		/// </summary>
		public static MergeOptions Empty => empty;

		#endregion

	}
}
