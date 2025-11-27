using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Services;
using Aspose.Zip;
using System;
using System.IO;
using System.Linq;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Message_Handlers
{
    public class ConvertZIPtoJPGTests : TestsBase
    {
        public ConvertZIPtoJPGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("message-handler");
        }


        // @START_SNIPPET ZipArchiveMessageHandler.cs
        // Implement ZipArchiveMessageHandler in C#
        // Learn more: https://docs.aspose.com/html/net/message-handlers/convert-html-from-zip-archive-to-jpg/

        // This message handler prints a message about start and finish processing request
        class ZipArchiveMessageHandler : MessageHandler, IDisposable
        {
            private string filePath;
            private Archive archive;

            // Initialize an instance of the ZipArchiveMessageHandler class
            public ZipArchiveMessageHandler(string path)
            {
                this.filePath = path;
                Filters.Add(new ProtocolMessageFilter("zip"));
            }

            // Override the Invoke() method
            public override void Invoke(INetworkOperationContext context)
            {
                // Call the GetFile() method that defines the logic in the Invoke() method
                byte[] buff = GetFile(context.Request.RequestUri.Pathname.TrimStart('/'));
                if (buff != null)
                {
                    // Checking: if a resource is found in the archive, then return it as a Response
                    context.Response = new ResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(buff)
                    };
                    context.Response.Headers.ContentType.MediaType = MimeType.FromFileExtension(context.Request.RequestUri.Pathname);
                }
                else
                {
                    context.Response = new ResponseMessage(HttpStatusCode.NotFound);
                }

                // Call the next message handler
                Next(context);
            }


            byte[] GetFile(string path)
            {
                path = path.Replace(@"\", @"/");
                ArchiveEntry result = GetArchive().Entries.FirstOrDefault(x => path == x.Name);
                if (result != null)
                {
                    using (Stream fs = result.Open())
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        return ms.ToArray();
                    }
                }
                return null;
            }

            Archive GetArchive()
            {
                return archive ??= new Archive(filePath);
            }

            public void Dispose()
            {
                archive?.Dispose();
            }
        }
        // @END_SNIPPET


        [Fact(DisplayName = "Convert Zip to JPG")]
        public void ConvertZIPtoJPGTest()
        {
            // @START_SNIPPET ConvertZipToJpg.cs
            // Convert HTML from a ZIP archive to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/message-handlers/convert-html-from-zip-archive-to-jpg/

            // Add this line before you try to use the 'IBM437' encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Prepare path to a source zip file
            string documentPath = Path.Combine(DataDir, "test.zip");

            // Prepare path for converted file saving
            string savePath = Path.Combine(OutputDir, "zip-to-jpg.jpg");

            // Create an instance of ZipArchiveMessageHandler
            using ZipArchiveMessageHandler zip = new ZipArchiveMessageHandler(documentPath);

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();

            // Add ZipArchiveMessageHandler to the chain of existing message handlers
            configuration
                .GetService<INetworkService>()
                .MessageHandlers.Add(zip);

            // Initialize an HTML document with specified configuration
            using HTMLDocument document = new HTMLDocument("zip:///test.html", configuration);

            // Create an instance of Rendering Options
            ImageRenderingOptions options = new ImageRenderingOptions()
            {
                Format = ImageFormat.Jpeg
            };

            // Create an instance of Image Device
            using ImageDevice device = new ImageDevice(options, savePath);

            // Render ZIP to JPG
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "zip-to-jpg.jpg")));
        }
    }
}
