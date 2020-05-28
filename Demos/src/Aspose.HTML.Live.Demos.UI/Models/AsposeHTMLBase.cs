using Aspose.HTML.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.HTML.Live.Demos.UI.Helpers;
using Aspose.HTML.Live.Demos.UI.Services;
using Aspose.HTML.Live.Demos.UI.Models.Common;
using Newtonsoft.Json.Linq;
using Path = System.IO.Path;


namespace Aspose.HTML.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeHTMLBase class 
	///</Summary>

	public class AsposeHTMLBase : ModelBase
	{
		/// <summary>
		/// Maximum number of files which can be uploaded for MVC Aspose.Pdf apps
		/// </summary>
		protected static int MaximumUploadFiles = 10;

		/// <summary>
		/// Original file format SaveAs option for multiple files uploading. By default, "-"
		/// </summary>
		protected const string SaveAsOriginalName = ".-";

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response MaximumFileLimitsResponse = new Response()
		{
			Status = $"Number of files should be equal or less {MaximumUploadFiles}",
			StatusCode = 500
		};

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};

		private static string[] inExtensions = {
			".htm", ".html", ".xhtml", ".mhtml", ".mht", ".epub", ".svg", ".zip", ".md"
		};
		public class Options
		{
			///<Summary>
			/// AppName
			///</Summary>
			public string AppName;
			///<Summary>
			/// FolderName
			///</Summary>
			public string FolderName;

			/// <summary>
			/// File Names
			/// </summary>
			public string[] FileNames;

			///<Summary>
			/// FileName
			///</Summary>
			public string FileName => (FileNames != null && FileNames.Length > 0) ? FileNames[0] : "";

			private string _outputType;

			/// <summary>
			/// By default, it is the extension of FileName - e.g. ".docx"
			/// </summary>
			public string OutputType
			{
				get => _outputType;
				set
				{
					if (!value.StartsWith("."))
						value = "." + value;
					_outputType = value.ToLower();
				}
			}

			///<Summary>
			/// ResultFileName
			///</Summary>
			public string ResultFileName = "";

			///<Summary>
			/// MethodName
			///</Summary>
			public string MethodName;
			///<Summary>
			/// ModelName
			///</Summary>
			public string ModelName;
			///<Summary>
			/// CreateZip
			///</Summary>
			public bool CreateZip = false;
			///<Summary>
			/// CheckNumberOfPages
			///</Summary>
			public bool CheckNumberOfPages = false;
			///<Summary>
			/// DeleteSourceFolder
			///</Summary>
			public bool DeleteSourceFolder = false;

			/// <summary>
			/// Output zip filename (without '.zip'), if CreateZip property is true
			/// By default, FileName + AppName
			/// </summary>
			public string ZipFileName;

			/// <summary>
			/// If there are multiple input files, create a single result file (if result format allows it) if True;
			/// else process each input file separately and return a zip archive
			/// </summary>
			public bool MergeMultiple = false;

			/// <summary>
			/// Container for additional parameters being passed in the API URL query
			/// </summary>
			private Dictionary<string, string> m_queryParams = null;

			/// <summary>
			/// AppSettings.WorkingDirectory + FolderName + "/" + FileName
			/// </summary>
			//public string WorkingFileName
			//{
			//	get
			//	{
			//		if (System.IO.File.Exists(AppSettings.WorkingDirectory + FolderName + "/" + FileName))
			//			return AppSettings.WorkingDirectory + FolderName + "/" + FileName;
			//		return AppSettings.OutputDirectory + FolderName + "/" + FileName;
			//	}
			//}


			/// <summary>
			/// Check if 'key' parameter has been specified in the request.
			/// </summary>
			/// <param name="key"></param>
			/// <returns></returns>
			public bool HasCustomParameter(string key)
			{
				return m_queryParams != null && m_queryParams.ContainsKey(key);
			}

			/// <summary>
			/// Extract parameters from the query string of HTTP request.
			/// </summary>
			/// <param name="request"></param>
			public void SetupCustomQueryParameters(HttpRequestMessage request)
			{
				if (m_queryParams == null)
				{
					m_queryParams = request.GetQueryNameValuePairs()
						.ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
				}
			}

			/// <summary>
			/// Get 'key' query parameter value (as string), if it has been specified, or null
			/// </summary>
			/// <param name="key"></param>
			/// <returns></returns>
			public string GetCustomParameter(string key)
			{
				if (m_queryParams.ContainsKey(key))
					return m_queryParams[key];
				return null;
			}

		}
		/// <summary>
		/// Obsolete method
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		protected Response ProcessTask(ActionDelegate action)
		{
			
			string productName = "AsposeHTML" + Opts.AppName;
			string methodName = Opts.MethodName;
			string folderName = Opts.FolderName;

			string fileName = Opts.FileName;

			
			string guid = Guid.NewGuid().ToString();
			string outFolder = "";
			string sourceFolder;
			if (!string.IsNullOrEmpty(folderName) && Path.IsPathRooted(folderName))
				sourceFolder = folderName;
			else
				sourceFolder = Config.Configuration.WorkingDirectory + folderName;

			string _logFileName = fileName;
			if (!Path.IsPathRooted(fileName))
				fileName = sourceFolder + "/" + fileName;
			string fileExtension = Path.GetExtension(fileName).ToLower();
			string outfileName = Path.GetFileNameWithoutExtension(fileName) + Opts.OutputType;
			string outPath = "";

			string zipOutFolder = Config.Configuration.OutputDirectory + guid;
			string zipOutfileName, zipOutPath;
			if (string.IsNullOrEmpty(Opts.ZipFileName))
			{
				zipOutfileName = guid + ".zip";
				zipOutPath = Config.Configuration.OutputDirectory + zipOutfileName;
			}
			else
			{
				var guid2 = Guid.NewGuid().ToString();
				outFolder = guid2;
				zipOutfileName = Opts.ZipFileName + ".zip";
				zipOutPath = Config.Configuration.OutputDirectory + guid2;
				Directory.CreateDirectory(zipOutPath);
				zipOutPath += "/" + zipOutfileName;
			}

			if (Opts.CreateZip)
			{
				outfileName = Path.GetFileNameWithoutExtension(fileName) + Opts.OutputType;
				outPath = zipOutFolder + "/" + outfileName;
				Directory.CreateDirectory(zipOutFolder);
			}
			else
			{
				outFolder = guid;
				outPath = Config.Configuration.OutputDirectory + outFolder;
				Directory.CreateDirectory(outPath);

				outPath += "/" + outfileName;
			}

			string statusValue = "OK";
			int statusCodeValue = 200;

			try
			{
				action(fileName, outPath, zipOutFolder);

				if (Opts.CreateZip)
				{
					ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
					Directory.Delete(zipOutFolder, true);
					outfileName = zipOutfileName;
				}

				if (Opts.DeleteSourceFolder)
				{
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
					Directory.Delete(sourceFolder, true);
				}
				
			}
			catch (Exception ex)
			{
				statusCodeValue = 500;
				statusValue = "500 " + ex.Message;
				
			}
			return new Response
			{
				FileName = outfileName,
				FolderName = outFolder,
				Status = statusValue,
				StatusCode = statusCodeValue,
			};
		}
		/// <summary>
		/// Method version used by new MVC-based implementation.
		/// </summary>
		/// <param name="fileNames"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		protected Response ProcessTask_(string[] fileNames, HtmlActionDelegate action)
		{
			
			string productName = "AsposeHTML" + Opts.AppName;
			string methodName = Opts.MethodName;
			string folderName = Opts.FolderName;
			

			string sourceFolder;
			if (!string.IsNullOrEmpty(folderName) && Path.IsPathRooted(folderName))
				sourceFolder = folderName;
			else
				sourceFolder = Config.Configuration.WorkingDirectory + folderName;

			string guid = Guid.NewGuid().ToString();
			string zipTmpFolder = Config.Configuration.OutputDirectory + guid;
			string zipOutfileName, zipOutPath = "";
			string outFolder = "", outFolderPath = "", outfileName = "";
			//string outPath;

			if (Opts.CreateZip)
			{
				if (string.IsNullOrEmpty(Opts.ZipFileName))
				{
					zipOutfileName = guid + ".zip";
					zipOutPath = Config.Configuration.OutputDirectory + zipOutfileName;
				}
				else
				{
					var guid2 = Guid.NewGuid().ToString();
					outFolder = guid2;
					zipOutfileName = Opts.ZipFileName + ".zip";
					zipOutPath = Config.Configuration.OutputDirectory + guid2;
					Directory.CreateDirectory(zipOutPath);
					zipOutPath += "/" + zipOutfileName;
				}
				outfileName = Opts.ZipFileName + Opts.OutputType;
				Directory.CreateDirectory(zipTmpFolder);
			}
			else
			{
				outfileName = Opts.ResultFileName + Opts.OutputType;
				outFolder = guid;
				outFolderPath = Config.Configuration.OutputDirectory + outFolder;
				Directory.CreateDirectory(outFolderPath);
			}

			string statusValue = "OK";
			int statusCodeValue = 200;
			try
			{
				if (Opts.CreateZip)
				{
					foreach (var fn in fileNames)
					{
						var outFile = Path.GetFileNameWithoutExtension(fn) + Opts.OutputType;
						var outPath = zipTmpFolder + "/" + outFile;
						action(new string[] { fn }, outPath, "");
					}
					ZipFile.CreateFromDirectory(zipTmpFolder, zipOutPath);
					Directory.Delete(zipTmpFolder, true);
					outfileName = Path.GetFileName(zipOutPath);
				}
				else
				{
					var outPath = $"{outFolderPath}/{outfileName}";
					action(fileNames, outPath, "");
					//if(fileNames.Length == 1)
					//{
					//	if(!System.IO.File.Exists(outPath))
					//	{
					//		DirectoryInfo dir = new DirectoryInfo(outFolderPath);
					//		var pattern = $"{Path.GetFileNameWithoutExtension(outfileName)}";
					//		var ff = dir.GetFiles(pattern);
					//		if (ff.Length > 0 && outfileName != ff[0].Name)
					//		{
					//			outfileName = ff[0].Name;
					//		}
					//	}
					//}
				}

				#region REM
				//if (Opts.MergeMultiple || !Opts.CreateZip)
				//{
				//	var outPath = $"{outFolderPath}/{outfileName}";
				//	action(fileNames, outPath, "");
				//}
				//else
				//{
				//	foreach(var fn in fileNames)
				//	{
				//		var outFile = Path.GetFileNameWithoutExtension(fn) + Opts.OutputType;
				//		var outPath = zipTmpFolder + "/" + outFile;
				//		action(new string[] { fn }, outPath, "");
				//	}
				//	if (Opts.CreateZip)
				//	{
				//		ZipFile.CreateFromDirectory(zipTmpFolder, zipOutPath);
				//		Directory.Delete(zipTmpFolder, true);
				//		outfileName = Path.GetFileName(zipOutPath);
				//	}
				//}
				#endregion
				if (Opts.DeleteSourceFolder)
				{
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
					Directory.Delete(sourceFolder, true);
				}

			}
			catch (Exception ex)
			{
				statusCodeValue = 500;
				statusValue = "500 " + ex.Message;
				
			}
			return new Response
			{
				FileName = outfileName,
				FolderName = outFolder,
				Status = statusValue,
				StatusCode = statusCodeValue,
			};
		}
		/// <summary>
		/// init Options
		/// </summary>
		protected Options Opts = new Options();

		/// <summary>
		/// UTF8WithoutBom
		/// </summary>
		protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);

		

		private object Lock1 = new object();
		private object Lock2 = new object();

		/// <summary>
		/// PageBase
		/// </summary>
		public AsposeHTMLBase()
		{
			
			Opts.ModelName = GetType().Name;
		}

		/// <summary>
		/// PageBase
		/// </summary>
		static AsposeHTMLBase()
		{
			Aspose.HTML.Live.Demos.UI.Models.License.SetAsposeHTMLLicense();
			
		}


		///<Summary>
		/// Prepare Archive file (mainly zipped HTML with local resources) to processing
		///</Summary>
		public void ProcessZipArchiveFile(ref string fileName, string folderName)
		{
			//If the input file is not zip file then return;
			if (Path.GetExtension(fileName).ToLower() != ".zip")
			{
				return;
			}
			//Extract zip file contents and prepare them for conversion.
			string destinationDirectoryName;
			if (Path.IsPathRooted(folderName))
				destinationDirectoryName = $"{folderName.Replace('\\', '/')}/";
			else
				destinationDirectoryName = $"{Path.Combine(Config.Configuration.WorkingDirectory, folderName).Replace('\\', '/')}/";

			string sourceArchiveFileName; ;
			if (Path.IsPathRooted(fileName))
				sourceArchiveFileName = fileName;
			else
				sourceArchiveFileName = destinationDirectoryName + Path.GetFileName(fileName);

			destinationDirectoryName = Path.Combine(Config.Configuration.WorkingDirectory.Replace('/', '\\'), Guid.NewGuid().ToString());
			System.IO.Compression.ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);

			string sourceFileName = "";

			string[] dirFiles = System.IO.Directory.GetFiles(destinationDirectoryName);
			for (int i = 0; i < dirFiles.Length; i++)
			{
				sourceFileName = dirFiles[i];
				string fileExt = Path.GetExtension(sourceFileName).ToLower();
				if (inExtensions.Contains(fileExt))
				{
					break;
				}
			}
			fileName = sourceFileName;
		}


		protected string CheckInputType(MultipartFormDataStreamProviderSafe uploadProvider, string _inputType)
		{
			if (uploadProvider.FileData[0] != null)
			{
				string inputFileName = uploadProvider.FileData[0].LocalFileName;
				string actualInputType = inputFileName.Substring(inputFileName.LastIndexOf('.') + 1);
				if (!_inputType.Equals(actualInputType))
					_inputType = actualInputType;
			}
			return _inputType;
		}





		/// <summary>
		/// 
		/// </summary>
		/// <param name="docs"></param>
		protected void SetDefaultOptions(InputFiles inputFiles, string outputType)
		{
			if (inputFiles.Count > 0)
			{
				
				SetDefaultOptions(inputFiles[0].FileName, outputType);
				Opts.CreateZip = inputFiles.Count > 1 && !Opts.MergeMultiple; /*|| (Opts.IsPicture)*/
			}
		}

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="filename"></param>
		private void SetDefaultOptions(string filename, string outputType)
		{
			Opts.ResultFileName = filename;
			//Opts.FileName = Path.GetFileName(filename);

			//var query = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
			//string outputType = null;
			//if (query.ContainsKey("outputType"))
			//	outputType = query["outputType"];
			Opts.OutputType = !string.IsNullOrEmpty(outputType)
			  ? outputType
			  : Path.GetExtension(Opts.FileName);

			Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
			  ? Opts.FileName
			  : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
		}

		

		protected Response Process(HtmlAsyncActionDelegate action)
		{
			if (string.IsNullOrEmpty(Opts.OutputType) && !string.IsNullOrEmpty(Opts.FileName))
				Opts.OutputType = Path.GetExtension(Opts.FileName);

			if (!(Opts.OutputType == ".pdf" || Opts.OutputType == ".xps"
				|| Opts.OutputType == ".tiff" || Opts.OutputType == ".tif"))
				Opts.CreateZip = true; // Opts.FileNames.Length > 1; // && !Opts.MergeMultiple);

			if (string.IsNullOrEmpty(Opts.ZipFileName))
				Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;

			return  action(Opts.FileNames, Opts.FolderName, Opts.OutputType);
		}







		#region Common
		/// <summary>
		/// IsValidRegex
		/// </summary>
		public static bool IsValidRegex(string pattern)
		{
			if (string.IsNullOrEmpty(pattern))
				return false;
			try
			{
				Regex.Match("", pattern);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		

		
		#endregion
	}

	
}
