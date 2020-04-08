using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.AdvancedUsage
{
    static class DOMMutationObserver
    {
        public static void ObserveHowNodesAreAdded()
        {
            //ExStart: ObserveHowNodesAreAdded
            // Create an empty HTML document
            using (var document = new HTMLDocument())
            {
                // Create a mutation observer instance
                var observer = new Aspose.Html.Dom.Mutations.MutationObserver((mutations, mutationObserver) =>
                {
                    foreach (var record in mutations)
                    {
                        foreach (var node in record.AddedNodes)
                        {
                            Console.WriteLine("The '" + node + "' node was added to the document.");
                        }
                    }
                });

                // configuration of the observer
                var config = new Aspose.Html.Dom.Mutations.MutationObserverInit
                {
                    ChildList = true,
                    Subtree = true,
                    CharacterData = true
                };

                // pass in the target node to observe with the specified configuration
                observer.Observe(document.Body, config);

                // Now, we are going to modify DOM tree to check
                // Create an paragraph element and append it to the document body
                var p = document.CreateElement("p");
                document.Body.AppendChild(p);
                // Create a text and append it to the paragraph
                var text = document.CreateTextNode("Hello World");
                p.AppendChild(text);

                Console.WriteLine("Waiting for mutation. Press any key to continue...");
                Console.ReadLine();
            }
            //ExEnd: ObserveHowNodesAreAdded
        }
    }
}
