using System;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications
{
	public class MatchResult<T> : MatchResult
	{
		public MatchResult(bool value, T data)
			: base(value)
		{
			this.Data = data;
		}

		public T Data { get; }
	}

	public class MatchResult : IEquatable<MatchResult>
	{
		public static readonly MatchResult True = new MatchResult(true);
		public static readonly MatchResult False = new MatchResult(false);

		private bool value;

		protected MatchResult(bool value)
			: this(value, 0)
		{

		}

		MatchResult(bool value, int errorCode)
		{
			this.value = value;
			this.ErrorCode = errorCode;
		}

		public static MatchResult Error(int errorCode)
		{
			return new MatchResult(false, errorCode);
		}

		public static MatchResult Result<T>(T data)
		{
			return new MatchResult<T>(true, data);
		}

		public int ErrorCode { get; }

		public static bool operator ==(MatchResult a, MatchResult b)
		{
			if (ReferenceEquals(a, b))
				return true;
			if (ReferenceEquals(a, null))
				return false;
			return a.Equals(b);
		}

		public static bool operator !=(MatchResult a, MatchResult b)
		{
			return !(a == b);
		}

		public bool Equals(MatchResult other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return this.value.Equals(other.value);
		}

		public override bool Equals(object obj)
		{
			return obj is MatchResult other && Equals(other);
		}

		public override string ToString()
		{
			return value.ToString();
		}
	}
}
