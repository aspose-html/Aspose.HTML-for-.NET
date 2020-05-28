using System.Collections.Generic;
using System.IO;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML
{
	class FileNameProvider : IFileNameProvider
	{
		Dictionary<string, int> usedNames = new Dictionary<string, int>();

		public string GetNextFileName(string fileName, string extension)
		{
			var name = Path.GetFileNameWithoutExtension(fileName);
			string key = fileName.ToUpperInvariant();
			if (usedNames.ContainsKey(key))
			{
				fileName = $"{name}_{++usedNames[key]}{extension}";
				return fileName;
			}
			else
			{
				fileName = $"{name}{extension}";
				usedNames.Add(key, 1);
				return fileName;
			}
		}
	}
}
