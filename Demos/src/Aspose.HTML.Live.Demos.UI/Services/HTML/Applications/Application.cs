using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications
{
	public abstract class Application<T> : Application
		where T : ApplicationOptions
	{


		protected Application(ApplicationId id)
			: base(id)
		{
		}

		protected Application(ApplicationId id, params ApplicationExecutionHandler[] handlers)
			: base(id)
		{
			this.Handlers = handlers;
		}

		public IList<ApplicationExecutionHandler> Handlers { get; }

		public override Result Execute(InputDataProvider data, ApplicationOptions options)
		{
			return Execute(data, (T) options);
		}

		MatchResult TryGetHandler(T options)
		{
			int lastErrorCode = MatchResult.False.ErrorCode;
			foreach (ApplicationExecutionHandler handler in Handlers)
			{
				var match = handler.CanExecute(options);
				if (match == MatchResult.True)
					return MatchResult.Result<ApplicationExecutionHandler>(handler);

				if (match.ErrorCode > lastErrorCode)
					lastErrorCode = match.ErrorCode;
			}

			if (lastErrorCode == MatchResult.False.ErrorCode)
				return MatchResult.False;

			return MatchResult.Error(lastErrorCode);
		}

		public virtual Result Execute(InputDataProvider data, T options)
		{
			var handler = TryGetHandler(options);

			if (handler == MatchResult.True)
				return ((MatchResult<ApplicationExecutionHandler>)handler).Data.Execute(data, options);

			return Result.Error(handler.ErrorCode);
		}
	}

	public abstract class Application
	{
		public static readonly TimeSpan DEFAULT_RENDERING_TIMEOUT = TimeSpan.FromSeconds(0);
		public const string DEFAULT_NAME_FOR_COVERTED_SET_OF_FILES = "Converted_Documents";
		public const string DEFAULT_NAME_FOR_MERGED_SET_OF_FILES = "Merged_Documents";


		protected Application(ApplicationId id)
		{
			Id = id;
		}
		
		public ApplicationId Id { get; }

		public abstract Result Execute(InputDataProvider data, ApplicationOptions options);
	}
}
