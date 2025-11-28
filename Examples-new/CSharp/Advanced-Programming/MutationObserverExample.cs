using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Mutations;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates how to use a MutationObserver to watch for DOM changes
    /// </summary>
    public class MutationObserverExample : BaseExample
    {
        public MutationObserverExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("advanced-programming/mutation-observer");
        }

        /// <summary>
        /// Executes the mutation observer example
        /// </summary>
        public void MutationObserver()
        {
            // Create an empty HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a mutation observer instance
                Html.Dom.Mutations.MutationObserver observer = new Html.Dom.Mutations.MutationObserver((mutations, mutationObserver) =>
                {
                    foreach (MutationRecord record in mutations)
                    {
                        foreach (Node node in record.AddedNodes)
                        {
                            Console.WriteLine("The '" + node + "' node was added to the document.");
                        }
                    }
                });

                // Configuration of the observer
                MutationObserverInit config = new MutationObserverInit
                {
                    ChildList = true,
                    Subtree = true,
                    CharacterData = true
                };

                // Pass in the target node to observe with the specified configuration
                observer.Observe(document.Body, config);

                // Now, we are going to modify DOM tree to check
                // Create a paragraph element and append it to the document body
                Element p = document.CreateElement("p");
                document.Body.AppendChild(p);

                // Create a text node and append it to the paragraph
                Text text = document.CreateTextNode("Hello, World");
                p.AppendChild(text);

                Console.WriteLine("Waiting for mutation. Press any key to continue...");
                // In a real scenario you might wait for asynchronous events;
                // here we simply output the messages.
            }
        }
    }
}