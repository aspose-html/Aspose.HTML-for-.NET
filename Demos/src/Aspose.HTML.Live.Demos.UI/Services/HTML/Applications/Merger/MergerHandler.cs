using Aspose.Html;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Merger
{
	abstract class MergerHandler : ApplicationExecutionHandler<MergerApplicationOptions>
	{
		protected MergerHandler(params ExecutionHandlerFilter[] filters)
			: base(filters)
		{
		}

		protected abstract RenderingWorkUnit CreateWorkItem(DataSource source, Configuration configuration);
	}
}
