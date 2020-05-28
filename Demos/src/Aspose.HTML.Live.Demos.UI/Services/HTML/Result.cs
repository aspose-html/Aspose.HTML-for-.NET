using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public class Result
	{
		public static Result Empty()
		{
			return new Result();
		}

		public static Result Error(Exception exception)
		{
			return new Result()
			{
				Exception = exception,
				ErrorCode = ErrorCodes.SystemException
			};
		}

		public static Result Error(int code)
		{
			return new Result()
			{
				ErrorCode = code
			};
		}

		public static Result FromDirectory(string directory)
		{
			return FromFiles(Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories));
		}

		public static Result FromFiles(params string[] files)
		{
			return new Result()
			{
				DataFiles = files
			};
		}

		public IList<string> DataFiles { get; private set; }

		public Exception Exception { get; private set; }

		public int ErrorCode { get; private set; }

		public bool IsValid
		{
			get { return ErrorCode == ErrorCodes.None && DataFiles?.Count > 0; }
		}
	}
}
