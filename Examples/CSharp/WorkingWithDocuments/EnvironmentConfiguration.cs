using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithDocuments
{
    static class EnvironmentConfiguration
    {
        public static void DisableScriptsExecution()
        {
            //ExStart: DisableScriptsExecution
            // Prepare an HTML code and save it to the file.
            var code = "<span>Hello World!!</span> " +
                       "<script>document.write('Have a nice day!');</script>";

            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of Configuration
            using (var configuration = new Aspose.Html.Configuration())
            {
                // Mark 'scripts' as an untrusted resource
                configuration.Security |= Aspose.Html.Sandbox.Scripts;

                // Initialize an HTML document with specified configuration
                using (var document = new Aspose.Html.HTMLDocument("document.html", configuration))
                {
                    // Convert HTML to PDF
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
                }
            }
            //ExEnd: DisableScriptsExecution
        }

        public static void SpecifyUserStyleSheet()
        {
            //ExStart: SpecifyUserStyleSheet
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello World!!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of Configuration
            using (var configuration = new Aspose.Html.Configuration())
            {
                // Get the IUserAgentService
                var userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();

                // Set the custom color to the SPAN element
                userAgent.UserStyleSheet = "span { color: green; }";
                
                // Initialize an HTML document with specified configuration
                using (var document = new Aspose.Html.HTMLDocument("document.html", configuration))
                {
                    // Convert HTML to PDF
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
                }
            }
            //ExEnd: SpecifyUserStyleSheet
        }

        public static void JavaScriptExecutionTimeout()
        {
            //ExStart: JavaScriptExecutionTimeout
            // Prepare an HTML code with endless loop
            var code = @"<script>while(true){}</script>";
            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of Configuration
            using (var configuration = new Aspose.Html.Configuration())
            {
                // Limit JS execution time to 10 seconds
                var runtime = configuration.GetService<Aspose.Html.Services.IRuntimeService>();
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(10);

                // Initialize an HTML document with specified configuration
                using (var document = new Aspose.Html.HTMLDocument("document.html", configuration))
                {
                    // Wait until all scripts are finished/canceled and convert HTML to PNG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(), "output.png");
                }
            }
            //ExEnd: JavaScriptExecutionTimeout
        }

        public static void CustomMessageHandler()
        {
            //ExStart: CustomMessageHandler
            // Prepare an HTML code with missing image file
            var code = @"<img src='missing.jpg'>";
            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of Configuration
            using (var configuration = new Aspose.Html.Configuration())
            {
                // Add ErrorMessageHandler to the chain of existing message handlers
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new LogMessageHandler());
                
                // Initialize an HTML document with specified configuration
                // During the document loading, the application will try to load the image and we will see the result of this operation in the console.
                using (var document = new Aspose.Html.HTMLDocument("document.html", configuration))
                {
                    // Convert HTML to PNG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(), "output.png");
                }
            }
            //ExEnd: CustomMessageHandler
        }

        /// <summary>
        /// This message handler logs all failed requests to the console.
        /// </summary>
        class LogMessageHandler : Aspose.Html.Net.MessageHandler
        {
            public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
            {
                // Check whether response is OK
                if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    // Log information to console
                    System.Console.WriteLine("File Not Found: " + context.Request.RequestUri);
                }

                // Invoke the next message handler in the chain.
                Next(context);
            }
        }
    }
}
