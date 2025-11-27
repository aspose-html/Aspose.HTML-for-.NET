using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Services;
using Aspose.Zip;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
    public class ZiptoPDFTimeLoggingTests : TestsBase
    {
        public ZiptoPDFTimeLoggingTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET RequestDurationLoggingMessageHandler.cs
        // Track and log HTTP request durations using C# message handlers
        // Learn more: https://docs.aspose.com/html/net/message-handlers/time-logging/

        // Define the RequestDurationLoggingMessageHandler class that is derived from the MessageHandler class
        abstract class RequestDurationLoggingMessageHandler : MessageHandler
        {
            private static ConcurrentDictionary<Url, Stopwatch> requests = new ConcurrentDictionary<Url, Stopwatch>();

            protected void StartTimer(Url url)
            {
                requests.TryAdd(url, Stopwatch.StartNew());
            }

            protected TimeSpan StopTimer(Url url)
            {
                Stopwatch timer = requests[url];
                timer.Stop();
                return timer.Elapsed;
            }
        }

        class StartRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                // Start the stopwatch
                StartTimer(context.Request.RequestUri);

                // Invoke the next message handler in the chain
                Next(context);
            }
        }

        class StopRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
        {
            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                // Stop the stopwatch
                TimeSpan duration = StopTimer(context.Request.RequestUri);

                // Print the result
                Debug.WriteLine($"Elapsed: {duration:g}, resource: {context.Request.RequestUri.Pathname}");

                // Invoke the next message handler in the chain
                Next(context);
            }
        }
        // @END_SNIPPET


        // @START_SNIPPET CustomSchemaMessageFilter.cs
        // Monitor network requests by custom protocol in C # using schema-based message filter and handler
        // Learn more: https://docs.aspose.com/html/net/message-handlers/time-logging/

        // Define the CustomSchemaMessageFilter class that is derived from the MessageFilter class
        class CustomSchemaMessageFilter : MessageFilter
        {
            private readonly string schema;
            public CustomSchemaMessageFilter(string schema)
            {
                this.schema = schema;
            }
            // Override the Match() method
            public override bool Match(INetworkOperationContext context)
            {
                return string.Equals(schema, context.Request.RequestUri.Protocol.TrimEnd(':'));
            }
        }

        // Define the CustomSchemaMessageHandler class that is derived from the MessageHandler class
        abstract class CustomSchemaMessageHandler : MessageHandler
        {
            // Initialize an instance of the CustomSchemaMessageHandler class
            protected CustomSchemaMessageHandler(string schema)
            {
                Filters.Add(new CustomSchemaMessageFilter(schema));
            }
        }
        // @END_SNIPPET


        // @START_SNIPPET ZipFileSchemaMessageHandler.cs
        // Handle zip file protocol requests in c#
        // Learn more: https://docs.aspose.com/html/net/message-handlers/time-logging/

        // Define the ZipFileSchemaMessageHandler class that is derived from the CustomSchemaMessageHandler class
        class ZipFileSchemaMessageHandler : CustomSchemaMessageHandler
        {
            private readonly Archive archive;

            public ZipFileSchemaMessageHandler(Archive archive) : base("zip-file")
            {
                this.archive = archive;
            }

            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                string pathInsideArchive = context.Request.RequestUri.Pathname.TrimStart('/').Replace("\\", "/");
                Stream stream = GetFile(pathInsideArchive);

                if (stream != null)
                {
                    // If a resource is found in the archive, then return it as a Response
                    ResponseMessage response = new ResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);
                    response.Headers.ContentType.MediaType = MimeType.FromFileExtension(context.Request.RequestUri.Pathname);
                    context.Response = response;
                }
                else
                {
                    context.Response = new ResponseMessage(HttpStatusCode.NotFound);
                }

                // Invoke the next message handler in the chain
                Next(context);
            }

            Stream GetFile(string path)
            {
                ArchiveEntry result = archive
                    .Entries
                    .FirstOrDefault(x => x.Name == path);
                return result?.Open();
            }
        }
        // @END_SNIPPET


        [Fact(DisplayName = "ZIP to PDF - Execution Time Logging")]
        public void ZIPtoPDFTimeLoggingTest()
        {
            // @START_SNIPPET ConvertZipToPdfWithDurationLogging.cs
            // Implement custom zip schema with request duration logging using C# message handlers
            // Learn more: https://docs.aspose.com/html/net/message-handlers/time-logging/

            // Add this line before you try to use the 'IBM437' encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Prepare path to a source zip file
            string documentPath = Path.Combine(DataDir, "test.zip");

            // Prepare path for converted file saving
            string savePath = Path.Combine(OutputDir, "zip-to-pdf-duration.pdf");

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;

            // Custom Schema: ZIP. Add ZipFileSchemaMessageHandler to the end of the pipeline
            handlers.Add(new ZipFileSchemaMessageHandler(new Archive(documentPath)));

            // Duration Logging. Add the StartRequestDurationLoggingMessageHandler at the first place in the pipeline
            handlers.Insert(0, new StartRequestDurationLoggingMessageHandler());

            // Add the StopRequestDurationLoggingMessageHandler to the end of the pipeline
            handlers.Add(new StopRequestDurationLoggingMessageHandler());

            // Initialize an HTML document with specified configuration
            using HTMLDocument document = new HTMLDocument("zip-file:///test.html", configuration);

            // Create the PDF Device
            using PdfDevice device = new PdfDevice(savePath);

            // Render ZIP to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
