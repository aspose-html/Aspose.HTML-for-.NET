using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Services;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates how to use CSS extensions (page‑margin marks) with Aspose.HTML
    /// </summary>
    public class CSSExtensionsExample : BaseExample
    {
        public CSSExtensionsExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("advanced-programming/css-extensions");
        }

        /// <summary>
        /// Executes the CSS extensions example.
        /// </summary>
        public void CSSExtensions()
        {
            // Initialize a configuration object and set up page‑margins for a document
            using (Configuration configuration = new Configuration())
            {
                // Get the User Agent service
                IUserAgentService userAgent = configuration.GetService<IUserAgentService>();

                // Set the style of custom margins and create marks on it
                userAgent.UserStyleSheet = @"@page 
                {
                    /* Page margins should be not empty in order to write content inside the margin-boxes */
                    margin-top: 1cm;
                    margin-left: 2cm;
                    margin-right: 2cm;
                    margin-bottom: 2cm;
                    /* Page counter located at the bottom of the page */
                    @bottom-right
                    {
                        -aspose-content: ""Page "" currentPageNumber() "" of "" totalPagesNumber();
                        color: green;
                    }

                    /* Page title located at the top-center box */
                    @top-center
                    {
                        -aspose-content: ""Hello, World Document Title!!!"";
                        vertical-align: bottom;
                        color: blue;
                    }
                }";

                // Initialize an HTML document
                using (HTMLDocument document = new HTMLDocument("<div>Hello, World!!!</div>", ".", configuration))
                {
                    // Initialize an output device (PDF)
                    using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "output.pdf")))
                    {
                        // Send the document to the output device
                        document.RenderTo(device);
                    }
                }
            }

            Console.WriteLine($"CSS extensions example completed. PDF saved to: {Path.Combine(OutputDir, "output.pdf")}");
        }
    }
}