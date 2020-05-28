namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public abstract class InputDataProvider : DataProvider
	{
		private DataRecordFactory factory;

		public InputDataProvider()
		{
			factory = new DataRecordFactory();
		}

		protected DataRecordFactory Factory => factory;
	}
}