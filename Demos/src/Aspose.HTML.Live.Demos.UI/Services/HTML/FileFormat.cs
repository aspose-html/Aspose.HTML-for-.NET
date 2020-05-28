using System;
using System.Collections.Generic;
//using System.Collections.Immutable;
using System.Diagnostics;


namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	/// <summary>
	/// Represents the enumeration of all known input and output file formats
	/// </summary>
	[DebuggerDisplay("FileFormat = {Name}")]
	public class FileFormat : IEquatable<FileFormat>
	{
		private static Dictionary<string, FileFormat> map;
		private string name;

		public static FileFormat Unknown = new FileFormat("");
		public static FileFormat HTML = RegisterKnownFormat("HTML", "HTM");
		public static FileFormat XHTML = RegisterKnownFormat("XHTML");
		public static FileFormat MHTML = RegisterKnownFormat("MHTML", "MHT");
		public static FileFormat EPUB = RegisterKnownFormat("EPUB");
		public static FileFormat SVG = RegisterKnownFormat("SVG");
		public static FileFormat MD = RegisterKnownFormat("MD");
		public static FileFormat PDF = RegisterKnownFormat("PDF");
		public static FileFormat XPS = RegisterKnownFormat("XPS");
		public static FileFormat JPEG = RegisterKnownFormat("JPEG", "JPG");
		public static FileFormat PNG = RegisterKnownFormat("PNG");
		public static FileFormat BMP = RegisterKnownFormat("BMP");
		public static FileFormat TIFF = RegisterKnownFormat("TIFF", "TIF");
		public static FileFormat GIF = RegisterKnownFormat("GIF");
		public static FileFormat ZIP = RegisterKnownFormat("ZIP");

		FileFormat(string name)
		{
			this.name = name;
		}

		static FileFormat RegisterKnownFormat(string name, params string[] alternateNames)
		{
			if (map == null)
				map = new Dictionary<string, FileFormat>();

			var key = name.Trim().ToUpperInvariant();
			var format = new FileFormat(key);
			map.Add(format.name, format);

			foreach (var alternateName in alternateNames)
				map.Add(alternateName.Trim().ToUpperInvariant(), format);

			return format;
		}

		public string Name => name;

		/// <summary>
		/// Determines whether the current instance is known format.
		/// </summary>
		public bool IsKnownFormat()
		{
			return map.ContainsKey(Name);
		}

		public bool Equals(FileFormat other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (!IsKnownFormat() && !other.IsKnownFormat())
				return true;
			return false;
		}

		public override bool Equals(object obj)
		{
			return obj is FileFormat other && Equals(other);
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Gets the <see cref="FileFormat"/> based on specified string.
		/// </summary>
		public static FileFormat Get(string name) 
		{
			var key = name.Trim().ToUpperInvariant();
			if (map.TryGetValue(key, out FileFormat format))
				return format;

			return new FileFormat(name);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.String" /> to <see cref="FileFormat" />.
		/// </summary>
		public static implicit operator FileFormat(string @string)
		{
			return Get(@string);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="FileFormat" /> to <see cref="System.String" />.
		/// </summary>
		public static implicit operator string(FileFormat type)
		{
			return type.Name;
		}

		/// <summary>
		/// Compares two File Format and returns a boolean indicating if the two do match.
		/// </summary>
		public static bool operator ==(FileFormat a, FileFormat b)
		{
			if (ReferenceEquals(a, b))
				return true;
			if (ReferenceEquals(a, null))
				return false;
			return a.Equals(b);
		}

		/// <summary>
		/// Compares two File Format and returns a boolean indicating if the two do match.
		/// </summary>
		public static bool operator !=(FileFormat a, FileFormat b)
		{
			return !(a == b);
		}
	}
}
