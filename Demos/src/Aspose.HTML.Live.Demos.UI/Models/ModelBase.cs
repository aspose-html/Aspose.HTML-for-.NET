using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;

namespace Aspose.HTML.Live.Demos.UI.Models
{
	///<Summary>
	/// ApiControllerBase class to have base methods
	///</Summary>

	public abstract class ModelBase : ApiController
	{

		///<Summary>
		/// ActionDelegate
		///</Summary>
		protected delegate void ActionDelegate(string inFilePath, string outPath, string zipOutFolder);
		/// <summary>
		/// /
		/// </summary>
		/// <param name="inputFiles"></param>
		/// <param name="outPath"></param>
		/// <param name="zipOutFolder"></param>
		protected delegate void HtmlActionDelegate(string[] inputFiles, string outPath, string zipOutFolder);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputFiles"></param>
		/// <param name="folderName"></param>
		/// <param name="outputType"></param>
		/// <returns></returns>
		public delegate Response HtmlAsyncActionDelegate(string[] inputFiles, string folderName, string outputType);

		///<Summary>
		/// inFileActionDelegate
		///</Summary>
		protected delegate void inFileActionDelegate(string inFilePath);
		///<Summary>
		/// Get File extension
		///</Summary>
		protected string GetoutFileExtension(string fileName, string folderName)
		{
			string sourceFolder = Aspose.HTML.Live.Demos.UI.Config.Configuration.WorkingDirectory + folderName;
			fileName = sourceFolder + "\\" + fileName;
			return Path.GetExtension(fileName);
		}

		

	}
}
