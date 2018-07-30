using Aspose.Html.Rendering.Xps;
using Aspose.Html.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithCSS
{
    class UseExtendedContentProperty
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            //  Initialize configuration object and set up the page-margins for the document
            Configuration configuration = new Configuration();
            configuration.GetService<IUserAgentService>().UserStyleSheet = @"
                                                                            @page 
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
                                                                                    -aspose-content: ""Document's title"";
                                                                                    vertical-align: bottom;
                                                                                }    
                                                                            }";

            //  Initialize an empty document
            using (HTMLDocument document = new HTMLDocument(configuration))
            {
                //  Initialize an output device
                using (XpsDevice device = new XpsDevice(dataDir + "output_out.xps"))
                {
                    // Send the document to the output device
                    document.RenderTo(device);
                }
            }
            // ExEnd:1
        }
    }
}
