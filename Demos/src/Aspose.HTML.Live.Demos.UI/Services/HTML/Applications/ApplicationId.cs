using System;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications
{
	public sealed class ApplicationId : IEquatable<ApplicationId>
	{
		public static readonly ApplicationId Conversion = new ApplicationId("conversion");
		public static readonly ApplicationId Merger = new ApplicationId("merger");

		ApplicationId(string name)
		{
			this.Name = name;
		}

		public string Name { get; }

		public bool Equals(ApplicationId other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;

			return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			return obj is ApplicationId other && Equals(other);
		}
	}
}
