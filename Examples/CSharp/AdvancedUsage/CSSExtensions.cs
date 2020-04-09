using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.AdvancedUsage
{
    static class CSSExtensions
    {
        public static void AddTitleAndPageNumber()
        {
            //ExStart: AddTitleAndPageNumber
            //  Initialize configuration object and set up the page-margins for the document
            using (Configuration configuration = new Configuration())
            {
                // Get the User Agent service
                var userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();

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
                                                    -aspose-content: ""Hello World Document Title!!!"";
                                                    vertical-align: bottom;
                                                    color: blue;
                                                }    
                                            }";

                //  Initialize an HTML document 
                using (HTMLDocument document = new HTMLDocument("<div>Hello World!!!</div>", ".", configuration))
                {
                    //  Initialize an output device
                    using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice("output.xps"))
                    {
                        // Send the document to the output device
                        document.RenderTo(device);
                    }
                }
            }
            //ExEnd: AddTitleAndPageNumber
        }
    }
}
