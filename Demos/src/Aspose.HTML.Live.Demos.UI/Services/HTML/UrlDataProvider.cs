using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Live.Demos.UI.Models;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	class UrlDataProvider : InputDataProvider
	{
		private IEnumerable<DataSource> data;

		public UrlDataProvider(params string[] files)
		{
			this.data = files.Select(x => Factory.CreateDataSource(x)).ToArray();
		}

		public override IEnumerable<DataSource> GetData()
		{
			return data;
		}
	}
}
