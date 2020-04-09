using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.AdvancedUsage
{
    static class HTMLFormEditor
    {
        public static void FillFormAndSubmitIt()
        {
            //ExStart: FillFormAndSubmitIt
            // Initialize an instance of HTML document from 'https://httpbin.org/forms/post' url
            using (var document = new Aspose.Html.HTMLDocument(@"https://httpbin.org/forms/post"))
            {
                // Create an instance of Form Editor
                using (var editor = Aspose.Html.Forms.FormEditor.Create(document, 0))
                {
                    // You can fill the data up using direct access to the input elements, like this:
                    editor["custname"].Value = "John Doe";

                    document.Save("out.html");

                    // or this:
                    var comments = editor.GetElement<Aspose.Html.Forms.TextAreaElement>("comments");
                    comments.Value = "MORE CHEESE PLEASE!";

                    // or even by performing a bulk operation, like this one:
                    editor.Fill(new Dictionary<string, string>()
                    {
                        {"custemail", "john.doe@gmail.com"},
                        {"custtel", "+1202-555-0290"}
                    });

                    // Create an instance of form submitter
                    using (var submitter = new Aspose.Html.Forms.FormSubmitter(editor))
                    {
                        // Submit the form data to the remote server.
                        // If you need you can specify user-credentials and timeout for the request, etc.
                        var result = submitter.Submit();

                        // Check the status of the result object
                        if (result.IsSuccess)
                        {
                            // Check whether the result is in json format
                            if (result.ResponseMessage.Headers.ContentType.MediaType == "application/json")
                            {
                                // Dump result data to the console
                                Console.WriteLine(result.Content.ReadAsString());
                            }
                            else
                            {
                                // Load the result data as an HTML document
                                using (var resultDocument = result.LoadDocument())
                                {
                                    // Inspect HTML document here.
                                }
                            }

                        }
                    }
                }
            }
            //ExEnd: FillFormAndSubmitIt
        }
    }
}
