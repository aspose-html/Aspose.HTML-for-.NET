using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Services;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
    public class NetworkOperationTimeoutsTests : TestsBase
    {
        public NetworkOperationTimeoutsTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET TimeoutMessageHandler.cs
        // Set custom timeout for network requests in .NET HTML processing
        // Learn more: https://docs.aspose.com/html/net/message-handlers/network-timeouts/

        // Define the TimeoutMessageHandler class that is derived from the MessageHandler class
        public class TimeoutMessageHandler : MessageHandler
        {
            public override void Invoke(INetworkOperationContext context)
            {
                context.Request.Timeout = TimeSpan.FromSeconds(1);
                Next(context);
            }
        }
        // @END_SNIPPET


        // @START_SNIPPET NetworkDisabledMessageHandler.cs
        // Disable external network access while allowing local and embedded resources
        // Learn more: https://docs.aspose.com/html/net/message-handlers/network-requests/

        // Define the NetworkDisabledMessageHandler class that is derived from the MessageHandler class
        public class NetworkDisabledMessageHandler : MessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                if (context.Request.RequestUri.Protocol == "file:" ||
                    context.Request.RequestUri.Protocol == "base64:" ||
                    context.Request.RequestUri.Protocol == "about:")
                    Next(context);
            }
        }
        // @END_SNIPPET

        /*
       // @START_SNIPPET NetworkChangeMessageHandler.cs
       // Define the NetworkChangeMessageHandler class that is derived from the MessageHandler class
    public class NetworkChangeMessageHandler : MessageHandler
    {
        // Override the Invoke() method
        public override void Invoke(INetworkOperationContext context)
        {
            if (context.Request.RequestUri.Protocol == "file:" || context.Request.RequestUri.Protocol == "base64:")
            {
                Next(context);
                return;
            }

            context.Request.RequestUri = new Url(context.Request.RequestUri.Pathname, "http://localhost:8080");
        }
    }
       // @END_SNIPPET


       [Fact(DisplayName = "Change Uri Requests")]
       public void ChangeUriRequestsTest()
       {
           {
               // Create an instance of the Configuration class
               using var configuration = new Configuration();

               // Call the INetworkService which contains the functionality for managing network operations
               var network = configuration.GetService<INetworkService>();

               // Add the CustomNetworkMessageHandler to the top of existing message handler chain
               network.MessageHandlers.Insert(0, new NetworkChangeMessageHandler());

               // Create a URL for testing (this URL will be intercepted by the custom message handler)
               string url = "https://products.aspose.com/html/";

               // Create an HTML document with a custom configuration
               var document = new HTMLDocument(url, configuration);

               // Perform a sample network request
               var response = network.Equals(document);

               // Display the response
               Output.WriteLine($"Response: {response}");
           }
       }*/


        [Fact(DisplayName = "Change Uri Requests")]
        public void ChangeUriRequests2Test()
        {
            {
                // Create an instance of the Configuration class
                using Configuration configuration = new Configuration();

                // Call the INetworkService which contains the functionality for managing network operations
                INetworkService network = configuration.GetService<INetworkService>();

                // Add the TimeoutMessageHandler to the top of existing message handler chain
                network.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

                // Prepare path to a source document file
                string documentPath = Path.Combine(DataDir, "document.html");

                // Create an HTML document with a custom configuration
                using HTMLDocument document = new HTMLDocument(documentPath, configuration);

                //  Similar with SNIPPET InterceptNetworkRequests
            }
        }


        [Fact(DisplayName = "Network Operation Timeouts - Open a File")]
        public void NetworkTimeoutsOpenFileTest()
        {
            // @START_SNIPPET AddCustomTimeoutMessageHandlerToNetworkService.cs
            // Set custom request timeout using a message handler
            // Learn more: https://docs.aspose.com/html/net/message-handlers/network-timeouts/

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Call the INetworkService which contains the functionality for managing network operations
            INetworkService network = configuration.GetService<INetworkService>();

            // Add the TimeoutMessageHandler to the top of existing message handler chain
            network.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Prepare path to a source document file
            string documentPath = Path.Combine(DataDir, "document.html");

            // Create an HTML document with a custom configuration
            using HTMLDocument document = new HTMLDocument(documentPath, configuration);

            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Network Operation Timeouts - Conversion")]
        public void NetworkTimeoutsConvertTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithCustomTimeoutHandler.cs
            // Set request timeout when converting HTML to PDF
            // Learn more: https://docs.aspose.com/html/net/message-handlers/network-timeouts/

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Call the INetworkService which contains the functionality for managing network operations
            INetworkService network = configuration.GetService<INetworkService>();

            // Add the TimeoutMessageHandler to the top of existing message handler chain
            network.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Prepare path to a source document file
            string documentPath = Path.Combine(DataDir, "document.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "document.pdf");

            // Convert HTML to PDF with customized configuration
            Converter.ConvertHTML(documentPath, configuration, new PdfSaveOptions(), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Intercept Network Requests")]
        public void InterceptNetworkRequestsTest()
        {
            {
                // @START_SNIPPET InterceptNetworkRequests.cs
                // Disable network requests when loading HTML
                // Learn more: https://docs.aspose.com/html/net/message-handlers/network-requests/

                // Create an instance of the Configuration class
                using Configuration configuration = new Configuration();

                // Call the INetworkService which contains the functionality for managing network operations
                INetworkService network = configuration.GetService<INetworkService>();

                // Add the TimeoutMessageHandler to the top of existing message handler chain
                network.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

                // Prepare path to a source document file
                string documentPath = Path.Combine(DataDir, "document.html");

                // Create an HTML document with a custom configuration
                using HTMLDocument document = new HTMLDocument(documentPath, configuration);

                // @END_SNIPPET

                // Perform a sample network request
                bool response = network.Equals(document);

                // Display the response
                Output.WriteLine($"Response: {response}");
            }
        }
    }
}
