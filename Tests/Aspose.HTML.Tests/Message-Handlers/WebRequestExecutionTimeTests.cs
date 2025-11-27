using System.Diagnostics;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
   public class WebRequestExecutionTimeTests : TestsBase
    {
        public WebRequestExecutionTimeTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET TimeLoggerMessageHandler.cs
        // Log request time with custom C# message handler
        // Learn more: https://docs.aspose.com/html/net/message-handlers/web-request-execution-time/

        // Define the TimeLoggerMessageHandler class that is derived from the MessageHandler class
        public class TimeLoggerMessageHandler : MessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                // Start the stopwatch
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Invoke the next message handler in the chain
                Next(context);

                // Stop the stopwatch
                stopwatch.Stop();

                // Print the result
                Debug.WriteLine("Request: " + context.Request.RequestUri);
                Debug.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + "ms");
            }
        }
        // @END_SNIPPET


        [Fact(DisplayName = "Web Request Execution Time")]
        public void WebRequestExecutionTimeTest()
        {
            // @START_SNIPPET WebRequestExecutionTime.cs
            // Track HTML load time in C# using a custom network message handler
            // Learn more: https://docs.aspose.com/html/net/message-handlers/web-request-execution-time/

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Add the TimeLoggerMessageHandler to the chain of existing message handlers
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
           
            handlers.Insert(0, new TimeLoggerMessageHandler());

            // Prepare path to a source document file
            string documentPath = Path.Combine(DataDir, "input.htm");

            // Initialize an HTML document with specified configuration
            using HTMLDocument document = new HTMLDocument(documentPath, configuration);

            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }
    }
}
