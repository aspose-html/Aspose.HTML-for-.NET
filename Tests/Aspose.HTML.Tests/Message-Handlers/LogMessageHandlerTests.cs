using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
    
    
    public class LogMessageHandlerTests : TestsBase
    {
        public LogMessageHandlerTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET LogMessageHandler.cs
        // Implement a message handler that prints a message about starting and finishing processing request
        // Learn more: https://docs.aspose.com/html/net/message-handlers/custom-message-handler/

        public class LogMessageHandler : MessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                Debug.WriteLine("Start processing request: " + context.Request.RequestUri);

                // Invoke the next message handler in the chain
                Next(context);

                Debug.WriteLine("Finish processing request: " + context.Request.RequestUri);
            }
        }
        // @END_SNIPPET


        [Fact(DisplayName = "Create a Custom Message Handler")]
        public void CreateACustomMessageHandlerTest()
        {
            // @START_SNIPPET CreateACustomMessageHandler.cs
            // Log network requests for HTML processing in C#
            // Learn more: https://docs.aspose.com/html/net/message-handlers/custom-message-handler/

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Add the LogMessageHandler to the chain of existing message handlers
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
                    
            handlers.Insert(0, new LogMessageHandler());

            // Prepare path to a source document file
            string documentPath = Path.Combine(DataDir, "input.htm");

            // Initialize an HTML document with specified configuration
            using HTMLDocument document = new HTMLDocument(documentPath, configuration);

            // @END_SNIPPET
            Assert.Contains("<html>", document.DocumentElement.OuterHTML);
        }
    }
}
