using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Forms;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Advanced_Programming
{
    public class HTMLFormEditor : TestsBase
    {
        public HTMLFormEditor(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("advanced-programming/html-form");
        }


        [Fact(DisplayName = "HTML Form Editor")]
        public void HTMLFormEditorTest()
        {
            // @START_SNIPPET FillAndSubmitHtmlForm.cs
            // How to to programmatically fill and submit an HTML form in C#
            // Learn more: https://docs.aspose.com/html/net/html-form-editor/

            // Initialize an instance of HTML document
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "form.html")))
            {
                // Create an instance of Form Editor
                using (FormEditor editor = Aspose.Html.Forms.FormEditor.Create(document, 0))
                {
                    // You can fill the data up using direct access to the input elements, like this:
                    editor["custname"].Value = "John Doe";

                    document.Save("out.html");

                    // or this:
                    TextAreaElement comments = editor.GetElement<Aspose.Html.Forms.TextAreaElement>("comments");
                    comments.Value = "MORE CHEESE PLEASE!";

                    // or even by performing a bulk operation, like this one:
                    editor.Fill(new Dictionary<string, string>()
                    {
                        {"custemail", "john.doe@gmail.com"},
                        {"custtel", "+1202-555-0290"}
                    });

                    // Create an instance of form submitter
                    using (FormSubmitter submitter = new Aspose.Html.Forms.FormSubmitter(editor))
                    {
                        // Submit the form data to the remote server
                        // If you need you can specify user-credentials and timeout for the request, etc.
                        SubmissionResult result = submitter.Submit();

                        // Check the status of the result object
                        if (result.IsSuccess)
                        {
                            // Check whether the result is in json format
                            if (result.ResponseMessage.Headers.ContentType.MediaType == "application/json")
                            {
                                // Dump result data to the console
                                Output.WriteLine(result.Content.ReadAsString());
                            }
                            else
                            {
                                // Load the result data as an HTML document
                                using (Document resultDocument = result.LoadDocument())
                                {
                                    // Inspect HTML document here.
                                }
                            }
                        }
                    }
                }
                Assert.Equal("HTML", document.DocumentElement.TagName);
            }
            // @END_SNIPPET
        }
    }
}
