using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class XPathTests : TestsBase
    {
        public XPathTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/xpath");
        }


        [Fact(DisplayName = "Use XPath")]
        public void XPathUsageTest1()
        {
            // Create an instance of an HTML document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                // Evaluate the XPath expression
                IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                // Iterate over the resulted nodes and print them to the console
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Output.WriteLine(img.Src);
                }
                Assert.True(doc.QuerySelectorAll("img").Length > 0);
            } 
        }


        [Fact(DisplayName = "Use XPath")]
        public void XPathUsageTest2()
        { 
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//main//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Output.WriteLine(img.Src);
                }
                Assert.True(doc.QuerySelectorAll(".ad").Length > 0);
            }            
        }


        [Fact(DisplayName = "Use XPath to Get Links to Images")]
        public void UseXPathToGetLinksToImagesTest()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//main/div[position() mod 2 = 1]//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Output.WriteLine(img.Src);
                }
                Assert.True(doc.QuerySelectorAll("div").Length > 0);
            }
        }


        [Fact(DisplayName = "Use XPath to Get Only Links to Photos From HTML")]
        public void UseXPathToGetLinksToPhotosTest()
        {
            // @START_SNIPPET UseXPathToGetLinksToPhotos.cs
            // Use XPath to get only links to photos from HTML
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-xpath/

            // Create an instance of an HTML document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                // Evaluate the XPath expression
                IXPathResult result = doc.Evaluate("//main/div[position() mod 2 = 1]//img[@class = 'photo']", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                // Iterate over the resulted nodes and print them to the console
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Output.WriteLine(img.Src);
                }
                Assert.True(doc.QuerySelectorAll(".photo").Length > 0);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Use XPath to Select all “Dealer” Nodes in XML")]
        public void XPathUsageInXMLTest()
        {
            // Create an instance of a document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                // Evaluate the XPath expression
                IXPathResult dealers = doc.Evaluate("//Dealer", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;

                // Iterate over the resulted nodes and print their contents to the console
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Output.WriteLine(dealer.TextContent);
                }
                Assert.True(doc.QuerySelectorAll("Car").Length > 0);
            }
        }


        [Fact(DisplayName = "Select Nodes using XPath Axes")]
        public void SelectNodesUsingXPathAxesTest()
        {
            // Create an instance of a document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                // Select dealers that match XPath expression
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;

                // Iterate over the selected dealers
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Output.WriteLine(dealer.TextContent);
                }
                Assert.True(doc.QuerySelectorAll("Cars").Length > 0);
            }
        }


        [Fact(DisplayName = "Use XPath to Select Nodes From XML")]
        public void UseXPathToSelectNodesFromXMLTest()
        {
            // @START_SNIPPET UseXPathToSelectNodesFromXml.cs
            // Use XPath to select nodes from XML
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-xpath-to-select-xml-nodes/

            // Create an instance of a document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                // Select dealers that match XPath expression
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;

                // Iterate over the selected dealers
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Output.WriteLine(dealer.TextContent);
                }
                Assert.True(doc.QuerySelectorAll("Name").Length > 0);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Use XPath To Pick Specific Information from Selected Nodes")]
        public void XPathToPickSpecificInformationTest()
        {
            // Create an instance of a document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                // Select dealers that match XPath expression
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;

                // Iterate over the selected dealers
                while ((dealer = dealers.IterateNext()) != null)
                {
                    // Get and print Dealer name and Telephone
                    IXPathResult dealerInfo = doc.Evaluate("concat('Dealer name: ', Name/text(), ' Telephone: ', Telephone/text())", dealer, doc.CreateNSResolver(doc), XPathResultType.String, null);
                    Output.WriteLine(dealerInfo.StringValue);
                }
                Assert.True(doc.QuerySelectorAll("Type").Length > 0);
            }
        }


        [Fact(DisplayName = "Use XPath in XML to Pick Specific Information")]
        public void UseXPathInXMLtoPickSpecificInformationTest()
        {
            // @START_SNIPPET UseXPathInXmlToPickSpecificInformation.cs
            // Query and extract XML data using XPath expressions
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-xpath-to-select-xml-nodes/

            // Create an instance of a document
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                // Select dealers that match XPath expression
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;

                // Iterate over the selected dealers
                while ((dealer = dealers.IterateNext()) != null)
                {
                    // Get and print Dealer name and Telephone
                    IXPathResult dealerInfo = doc.Evaluate("concat('Dealer name: ', Name/text(), ' Telephone: ', Telephone/text())", dealer, doc.CreateNSResolver(doc), XPathResultType.String, null);
                    Output.WriteLine(dealerInfo.StringValue);

                    // Select and print CarID that match XPath expression
                    IXPathResult carIds = doc.Evaluate(".//Car[descendant::Model > 2005 and descendant::Price < 25000]/@CarID", dealer, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                    Node carId;

                    while ((carId = carIds.IterateNext()) != null)
                    {
                        Output.WriteLine("Car id: " + carId.TextContent);
                    }
                }
                Assert.True(doc.QuerySelectorAll("Price").Length > 0);
            }
            // @END_SNIPPET
        }
    }
}
