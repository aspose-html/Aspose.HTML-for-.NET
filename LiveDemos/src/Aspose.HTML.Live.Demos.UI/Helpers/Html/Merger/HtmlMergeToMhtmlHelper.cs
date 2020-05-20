using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Css;
using Aspose.Html.Saving;


namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Merger
{
	public class HtmlMergeToMhtmlHelper
	{
		private string _htmlOutputPath;
		private string _content = @"
                        .button {
                            display: inline-block;
                            width: 115px;
                            height: 25px;
                            background: #4e9caf;
                            text-decoration:none;
                            padding: 10px;
                            text-align: center;
                            border-radius: 5px;
                            color: white;
                            font-weight: normal;
                            margin: 5px 20px 5px 0;
                        }

                        .title{
                            margin: 0;
                            alignment: center;
                            border-bottom: #005163 1px solid;
                        }

                        .container{
                            alignment: center;
                            border-style: solid;
                            padding: 0;
                            border-width: 1px ;
                            border-radius: 8px;
                            border-color: #005163;
                        }

                        a:hover {
                            background-color: #0f697b;
                        }";

		public void Merge(string[] htmlFiles, string outPath)
		{
			_htmlOutputPath = Path.GetDirectoryName(outPath);
			var temp = Path.Combine(_htmlOutputPath, "Output2");
			Directory.CreateDirectory(temp);

			for (var i = 0; i < htmlFiles.Length; i++)
			{
				var htmlFile = htmlFiles[i];
				var fileName = Path.GetFileName(htmlFile);
				var tempOutputFilePath = Path.Combine(temp, fileName);
				File.Copy(htmlFile, tempOutputFilePath);
				htmlFiles[i] = tempOutputFilePath;

				using (var htmlDocument = new HTMLDocument(htmlFiles[i]))
				{
					HTMLDivElement anchorDivContainer = (HTMLDivElement)htmlDocument.CreateElement("div");
					HTMLBodyElement htmlDocumentBody = (HTMLBodyElement)htmlDocument.Body;
					HTMLHeadElement head = (HTMLHeadElement)htmlDocument.GetElementsByTagName("head")[0];
					HTMLStyleElement htmlStyleElement = (HTMLStyleElement)htmlDocument.CreateElement("style");

					var resetEvent = new AutoResetEvent(false);
					htmlStyleElement.OnLoad += (sender, e) => { resetEvent.Set(); };
					htmlStyleElement.OnError += (sender, e) => { resetEvent.Set(); };

					var cssContent = htmlDocument.CreateTextNode(_content);
					htmlStyleElement.AppendChild(cssContent);
					head.AppendChild(htmlStyleElement);
					resetEvent.WaitOne();

					anchorDivContainer.SetAttribute("class", "container");
					anchorDivContainer.SetAttribute("align", "center");

					var paragraphElement = GetParagraphElement(htmlDocument, "Navigation");
					anchorDivContainer.AppendChild(paragraphElement);

					if (i != 0)
					{
						var anchorBackward = GetAnchorElement(htmlDocument, "Backward");
						anchorBackward.Href = Path.GetFileName(htmlFiles[i - 1]);
						anchorDivContainer.AppendChild(anchorBackward);
					}
					else
					{
						HTMLAnchorElement anchorBackward = GetAnchorElement(htmlDocument, "Backward");
						anchorBackward.Href = Path.GetFileName(htmlFiles[htmlFiles.Length - 1]);
						anchorDivContainer.AppendChild(anchorBackward);
					}

					if (i != htmlFiles.Length - 1)
					{
						HTMLAnchorElement anchorForward = GetAnchorElement(htmlDocument, "Forward");
						anchorForward.Href = Path.GetFileName(htmlFiles[i + 1]);
						anchorDivContainer.AppendChild(anchorForward);
					}
					else
					{
						HTMLAnchorElement anchorForward = GetAnchorElement(htmlDocument, "Forward");
						anchorForward.Href = Path.GetFileName(htmlFiles[0]);
						anchorDivContainer.AppendChild(anchorForward);
					}

					Node firstChild = htmlDocumentBody.FirstChild;
					htmlDocumentBody.InsertBefore(anchorDivContainer, firstChild);
					var outputPath = Path.Combine(_htmlOutputPath, fileName);
					htmlDocument.Save(outputPath);
					htmlDocument.Dispose();
					htmlFiles[i] = outputPath;
					ClearDirectory(temp);
				}

			}
			var name = Path.GetFileNameWithoutExtension(outPath);
			SaveDocument($"{name}.mhtml", htmlFiles[0], htmlFiles.Length);
		}

		private void SaveDocument(string name, String htmlPath, int handlingDepth)
		{
			var outPath = Path.Combine(_htmlOutputPath, name);
			Console.WriteLine(Path.GetFullPath(outPath));
			MHTMLSaveOptions mhtmlSaveOptions = new MHTMLSaveOptions();
			mhtmlSaveOptions.ResourceHandlingOptions.UrlRestriction = UrlRestriction.SameHost;
			mhtmlSaveOptions.ResourceHandlingOptions.MaxHandlingDepth = handlingDepth;
			using (var htmlContainer = new HTMLDocument(htmlPath))
			{
				htmlContainer.Save(outPath, mhtmlSaveOptions);
			}
		}

		private HTMLParagraphElement GetParagraphElement(HTMLDocument htmlDocument, string content)
		{
			HTMLParagraphElement paragraphElement = (HTMLParagraphElement)htmlDocument.CreateElement("p");
			paragraphElement.SetAttribute("class", "title");
			Text text = htmlDocument.CreateTextNode(content);
			paragraphElement.AppendChild(text);
			return paragraphElement;
		}

		private HTMLAnchorElement GetAnchorElement(HTMLDocument htmlDocument, string buttonText)
		{
			HTMLAnchorElement anchorElement = (HTMLAnchorElement)htmlDocument.CreateElement("a");

			Text backwardText = htmlDocument.CreateTextNode(buttonText);
			anchorElement.SetAttribute("class", "button");
			anchorElement.AppendChild(backwardText);
			return anchorElement;
		}

		private void ClearDirectory(string dirPath)
		{
			DirectoryInfo di = new DirectoryInfo(dirPath);
			if (di.Exists == false)
			{
				throw new ArgumentException("Non existing directory to clear");
			}

			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			foreach (DirectoryInfo subDi in di.GetDirectories())
			{
				subDi.Delete(true);
			}
		}
	}
}
