using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Models.Common
{
	public class InputFile
	{
		private string _fileName = string.Empty;
		private string _folderName = string.Empty;
		private string _localFileName = string.Empty;


		public InputFile(string fileName, string folderName , string localFileName)
		{
			_fileName = fileName;
			_folderName = folderName;
			_localFileName = localFileName;
		}
		public string LocalFileName
		{
			get { return _localFileName; }

		}
		public string FileName
		{
			get { return _fileName; }
			
		}
		public string FolderName
		{
			get { return _folderName; }
			
		}
		
	}

	public class InputFiles : List<InputFile>
	{

	}
}