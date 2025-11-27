using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Mutations;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Advanced_Programming
{
    public class MutationObserver : TestsBase
    {
        public MutationObserver(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("advanced-programming/mutation-observer");
        }


        [Fact(DisplayName = "MutationObservers")]
        public void MutationObserverTest()
        {
            // @START_SNIPPET MutationObserver.cs
            // Use Mutation Observer to watch for new nodes added to a document with C#
            // Learn more: https://docs.aspose.com/html/net/mutationobserver/

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
                            Output.WriteLine("The '" + node + "' node was added to the document.");
                        }
                    }
                });

                // Configuration of the observer
                MutationObserverInit config = new Html.Dom.Mutations.MutationObserverInit
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

                // Create a text and append it to the paragraph
                Text text = document.CreateTextNode("Hello, World");
                p.AppendChild(text);

                Output.WriteLine("Waiting for mutation. Press any key to continue...");
                Output.ToString();
            }
            // @END_SNIPPET
        }
    }
}
