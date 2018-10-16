using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Document
{
    public class LoadHTMLdocAsyn
    {
        public static void Run()
        {
            // ExStart:LoadHTMLdocAsyn
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            var document = new HTMLDocument();

            // subscribe to the event 'OnReadyStateChange' that will be fired once document is completely loaded
            document.OnReadyStateChange += (sender, @event) =>
            {
                if (document.ReadyState == "complete")
                {
                    // manipulate with document here
                }
            };
            document.Navigate(dataDir + "input.html");

            // ExEnd:LoadHTMLdocAsyn           
        }

        public static void EventNavigate()
        {
            // ExStart:EventNavigate
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            var document = new HTMLDocument();

            // you can subscribe to the event 'OnLoad'
            document.OnLoad += (sender, @event) =>
            {
                // manipulate with document here
            };
            document.Navigate(dataDir + "input.html");

            // ExEnd:EventNavigate
        }


    }
}
