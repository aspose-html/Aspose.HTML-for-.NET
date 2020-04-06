using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Document
{
    class CreateDocument
    {
        public static void Run()
        {
            CreateSVG();
            FromScratch();
            FromLocalFile();
            FromRemoteURL();
            FromRemoteURL1();
            FromHTML();
            FromStream();
        }

        private static void CreateSVG()
        {
            //ExStart: CreateSVG
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", "about:blank"))
            {
                // do some actions over the document here...
            }
            //ExEnd: CreateSVG
        }

        private static void FromScratch()
        {
            //ExStart: FromScratch
            using (var document = new Aspose.Html.HTMLDocument())
            {
                // do some actions over the document here...
            }
            //ExEnd: FromScratch
        }

        private static void FromLocalFile()
        {
            //ExStart: FromLocalFile
            string dataDir = RunExamples.GetDataDir_Data();
            using (var document = new Aspose.Html.HTMLDocument(dataDir+"input.html"))
            {
                // do some actions over the document here...
            }
            //ExEnd: FromLocalFile
        }

        private static void FromRemoteURL()
        {
            //ExStart: FromRemoteURL
            using (var document = new Aspose.Html.HTMLDocument("http://your.site.com/"))
            {
                // do some actions over the document here...
            }
            //ExEnd: FromRemoteURL
        }

        private static void FromRemoteURL1()
        {
            //ExStart: FromRemoteURL1
            using (var document = new Aspose.Html.HTMLDocument(new Url("http://your.site.com/")))
            {
                // do some actions over the document here...
            }
            //ExEnd: FromRemoteURL1
        }

        private static void FromHTML()
        {
            //ExStart: FromHTML
            using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", "."))
            {
                // do some actions over the document here...
            }
            //ExEnd: FromHTML
        }

        private static void FromStream()
        {
            //ExStart: FromStream
            using (MemoryStream mem = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(mem))
            {
                sw.Write("<p>my first paragraph</p>");

                // It is important to set the position to the beginning, since HTMLDocument starts the reading exactly from the current position within the stream.
                sw.Flush();
                mem.Seek(0, SeekOrigin.Begin);

                using (var document = new Aspose.Html.HTMLDocument(mem, "about:blank"))
                {
                    // do some actions over the document here...
                }
            }
            //ExEnd: FromStream
        }
    }
}
