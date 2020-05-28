using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	public abstract class DataProvider : IEnumerable<DataSource>, IDisposable
	{
		public IEnumerator<DataSource> GetEnumerator()
		{
			return GetData().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public abstract IEnumerable<DataSource> GetData();

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
