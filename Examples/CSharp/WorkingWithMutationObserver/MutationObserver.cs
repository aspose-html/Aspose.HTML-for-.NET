using Aspose.Html.Dom.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Aspose.Html.Examples.CSharp.WorkingWithMutationObserver
{
    public class MutationObserver
    {
        public static void Run()
        {
            // ExStart:MutationObserver
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            // The MutationObserver interface provides the ability to watch for changes being made to the DOM tree.

            // Create an empty document
            using (var document = new HTMLDocument())
            {
                // Create a WaitHandle for purpose described below
                var @event = new ManualResetEvent(false);

                // Create an observer instance
                var observer = new MutationObserver((mutations, mutationObserver) =>
                {
                    var mutation = mutations[0];
                    Console.WriteLine(mutation.AddedNodes[0]);
                    @event.Set();
                });

                // Options for the observer (which mutations to observe)
                var config = new MutationObserverInit
                {
                    ChildList = true,
                    Subtree = true
                };

                // Start observing the target node
                observer.Observe(document.DocumentElement, config);

                // An example of user modifications
                var p = document.CreateElement("p");
                document.DocumentElement.AppendChild(p);

                // Since, mutations are working in the async mode you should wait a bit. We use WaitHandle for this purpose.
                @event.WaitOne();


                // Later, you can stop observing
                observer.Disconnect();
            }
            // ExEnd:MutationObserver
        }
    }
}
