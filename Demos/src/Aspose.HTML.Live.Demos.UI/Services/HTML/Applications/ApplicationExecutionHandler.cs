using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications
{
	public abstract class ApplicationExecutionHandler<TOptions> : ApplicationExecutionHandler
		where TOptions : ApplicationOptions
	{

		protected ApplicationExecutionHandler(params ExecutionHandlerFilter[] filters)
		{
			this.Filters = filters.ToList();
		}

		public IList<ExecutionHandlerFilter> Filters { get; }

		public override MatchResult CanExecute(ApplicationOptions options)
		{
			return CanExecute((TOptions) options);
		}

		public virtual MatchResult CanExecute(TOptions options)
		{
			int lastErrorCode = MatchResult.False.ErrorCode;
			foreach (var filter in Filters)
			{
				var match = filter.Match(options);
				if (match == MatchResult.True)
					return MatchResult.True;

				if (match.ErrorCode > lastErrorCode)
					lastErrorCode = match.ErrorCode;
			}

			if (lastErrorCode == MatchResult.False.ErrorCode)
				return MatchResult.False;

			return MatchResult.Error(lastErrorCode);
		}

		public override Result Execute(InputDataProvider data, ApplicationOptions options)
		{
			return Execute(data, (TOptions) options);
		}

		public abstract Result Execute(InputDataProvider data, TOptions options);

		protected virtual Configuration GetConfiguration(TOptions options)
		{
			return new Configuration();
		}
	}

	public abstract class ApplicationExecutionHandler
	{
		public abstract MatchResult CanExecute(ApplicationOptions options);

		public abstract Result Execute(InputDataProvider data, ApplicationOptions options);

		protected abstract class RenderingWorkUnit : IDisposable
		{
			protected RenderingWorkUnit(object data)
			{
				this.Data = data;
			}

			public object Data { get; protected set; }

			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
				}
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
		}

		#region Unit of Work
		protected abstract class RenderingWorkUnit<T> : RenderingWorkUnit
		{
			protected RenderingWorkUnit(T data)
				: base(data)
			{
				this.Data = data;
			}

			public new T Data { get; protected set; }
		}

		protected class UrlWorkUnit : RenderingWorkUnit<string>
		{
			public UrlWorkUnit(string url, Configuration configuration)
				: base(url)
			{
			}
		}

		protected class StreamRenderingWorkUnit : RenderingWorkUnit<Stream>
		{
			public StreamRenderingWorkUnit(string url, Configuration configuration)
				: base(new FileStream(url, FileMode.Open, FileAccess.Read))
			{
			}

			protected override void Dispose(bool disposing)
			{
				if (Data != null)
				{
					Data.Dispose();
					Data = null;
				}
			}
		}

		protected class SVGDocumentRenderingWorkUnit : RenderingWorkUnit<SVGDocument>
		{
			public SVGDocumentRenderingWorkUnit(string url, Configuration configuration)
				: base(new SVGDocument(url, configuration))
			{
			}

			protected override void Dispose(bool disposing)
			{
				if (Data != null)
				{
					Data.Dispose();
					Data = null;
				}
			}
		}

		protected class HTMLDocumentRenderingWorkUnit : RenderingWorkUnit<HTMLDocument>
		{
			public HTMLDocumentRenderingWorkUnit(string url, Configuration configuration)
				: base(new HTMLDocument(url, configuration))
			{
			}

			protected override void Dispose(bool disposing)
			{
				if (Data != null)
				{
					Data.Dispose();
					Data = null;
				}
			}
		}

		protected class MarkdownDocumentRenderingWorkUnit : RenderingWorkUnit<HTMLDocument>
		{
			public MarkdownDocumentRenderingWorkUnit(string url, Configuration configuration)
				: base(Converter.ConvertMarkdown(url, configuration))
			{
			}

			protected override void Dispose(bool disposing)
			{
				if (Data != null)
				{
					Data.Dispose();
					Data = null;
				}
			}
		} 
		#endregion
	}
}
