using System;
using System.IO;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public abstract class DataSource : IDisposable
	{
		
		protected DataSource(string uri)
		{
			this.Uri = uri;
		}

		public virtual bool IsValid()
		{
			return true;
		}

		public virtual string Uri
		{
			get;
		}

		public string Name
		{
			get { return Path.GetFileNameWithoutExtension(Uri); }
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{

		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
