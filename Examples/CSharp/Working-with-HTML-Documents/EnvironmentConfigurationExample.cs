using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates various environment configuration scenarios
    /// </summary>
    public class EnvironmentConfigurationExample : BaseExample
    {
        public EnvironmentConfigurationExample()
        {
            // Sub‑directory for this example's output files
            SetOutputDir("configurations");
        }

        public void Sandboxing()
        {
            string code = "<span>Hello, World!!</span> " +
                          "<script>document.write('Have a nice day!');</script>";

            string htmlPath = Path.Combine(OutputDir, "sandboxing.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                configuration.Security |= Sandbox.Scripts;
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "sandboxing_out.pdf"));
                    Console.WriteLine($"Sandboxing example saved PDF to: {Path.Combine(OutputDir, "sandboxing_out.pdf")}");
                }
            }
        }

        public void BlockScriptExecution()
        {
            using (Configuration configuration = new Configuration())
            {
                configuration.Security |= Sandbox.Scripts;
                using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document-with-scripts.html"), configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "document-sandbox.pdf"));
                    Console.WriteLine($"Blocked script execution PDF saved to: {Path.Combine(OutputDir, "document-sandbox.pdf")}");
                }
            }
        }

        public void DisableImageLoading()
        {
            string code = "<span style=\"background-image:url('https://docs.aspose.com/html/images/work/lioness.jpg')\">Hello, World!!</span> " +
                          "<script>document.write('Have a nice day!');</script>";

            string htmlPath = Path.Combine(OutputDir, "sandboxing.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                configuration.Security |= Sandbox.Images;
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "sandboxing-out.pdf"));
                    Console.WriteLine($"Image loading disabled PDF saved to: {Path.Combine(OutputDir, "sandboxing-out.pdf")}");
                }
            }
        }

        public void UserAgentServiceStyleSheet()
        {
            string code = "<h1>User Agent Service </h1>\r\n" +
                          "<p>The User Agent Service allows you to specify a custom user stylesheet, a primary character set for the document, language and fonts settings.</p>\r\n";

            string htmlPath = Path.Combine(OutputDir, "user-agent-stylesheet.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();
                userAgentService.UserStyleSheet = "h1 { color:#a52a2a;; font-size:2em;}\r\n" +
                                                  "p { background-color:GhostWhite; color:SlateGrey; font-size:1.2em; }\r\n";

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "user-agent-stylesheet_out.pdf"));
                    Console.WriteLine($"User‑agent stylesheet PDF saved to: {Path.Combine(OutputDir, "user-agent-stylesheet_out.pdf")}");
                }
            }
        }

        public void UserAgentServiceCharacterSet()
        {
            string code = "<h1>Character Set</h1>\r\n" +
                          "<p>The <b>CharSet</b> property sets the primary character‑set for a document.</p>\r\n";

            string htmlPath = Path.Combine(OutputDir, "user-agent-charset.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();
                userAgentService.UserStyleSheet = "h1 { color:salmon; }\r\n" +
                                                  "p { background-color:#f0f0f0; color:DarkCyan; font-size:1.2em; }\r\n";
                userAgentService.CharSet = "ISO-8859-1";

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "user-agent-charset_out.pdf"));
                    Console.WriteLine($"User‑agent charset PDF saved to: {Path.Combine(OutputDir, "user-agent-charset_out.pdf")}");
                }
            }
        }

        public void UserAgentServiceFontSetting()
        {
            string code = "<h1>FontsSettings property</h1>\r\n" +
                          "<p>The FontsSettings property is used for configuration of fonts handling.</p>\r\n";

            string htmlPath = Path.Combine(OutputDir, "user-agent-fontsetting.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();
                userAgentService.UserStyleSheet = "h1 { color:#a52a2a; }\r\n" +
                                                  "p { color:grey; }\r\n";
                userAgentService.FontsSettings.SetFontsLookupFolder(Path.Combine(DataDir, "fonts"));

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "user-agent-fontsetting_out.pdf"));
                    Console.WriteLine($"User‑agent font setting PDF saved to: {Path.Combine(OutputDir, "user-agent-fontsetting_out.pdf")}");
                }
            }
        }

        public void RuntimeService()
        {
            string code = "<h1>Runtime Service</h1>\r\n" +
                          "<script> while(true) {} </script>\r\n" +
                          "<p>The Runtime Service optimizes your system by helping it start apps and programs faster.</p>\r\n";

            string htmlPath = Path.Combine(OutputDir, "runtime-service.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                IRuntimeService runtimeService = configuration.GetService<IRuntimeService>();
                runtimeService.JavaScriptTimeout = TimeSpan.FromSeconds(5);

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Png), Path.Combine(OutputDir, "runtime-service_out.png"));
                    Console.WriteLine($"Runtime service timeout example saved PNG to: {Path.Combine(OutputDir, "runtime-service_out.png")}");
                }
            }
        }

        public void NetworkService()
        {
            string code = "<img src=\"https://docs.aspose.com/svg/net/drawing-basics/filters-and-gradients/park.jpg\" >\r\n" +
                          "<img src=\"https://docs.aspose.com/html/net/missing1.jpg\" >\r\n" +
                          "<img src=\"https://docs.aspose.com/html/net/missing2.jpg\" >\r\n";

            string htmlPath = Path.Combine(OutputDir, "network-service.html");
            File.WriteAllText(htmlPath, code);

            using (Configuration configuration = new Configuration())
            {
                INetworkService networkService = configuration.GetService<INetworkService>();
                LogMessageHandler logHandler = new LogMessageHandler();
                networkService.MessageHandlers.Add(logHandler);

                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Png), Path.Combine(OutputDir, "network-service_out.png"));
                    Console.WriteLine($"Network service example saved PNG to: {Path.Combine(OutputDir, "network-service_out.png")}");
                }

                foreach (string error in logHandler.ErrorMessages)
                {
                    Console.WriteLine($"Network error logged: {error}");
                }
            }
        }

        // Helper class for logging network errors
        private class LogMessageHandler : MessageHandler
        {
            private readonly System.Collections.Generic.List<string> errors = new System.Collections.Generic.List<string>();
            public System.Collections.Generic.List<string> ErrorMessages => errors;

            public override void Invoke(INetworkOperationContext context)
            {
                if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    errors.Add($"File '{context.Request.RequestUri}' Not Found");
                }
                Next(context);
            }
        }
    }
}