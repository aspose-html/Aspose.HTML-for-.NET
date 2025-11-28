using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Forms;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates how to programmatically fill and submit an HTML form using Aspose.HTML
    /// </summary>
    public class HTMLFormEditorExample : BaseExample
    {
        public HTMLFormEditorExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("advanced-programming/html-form");
        }

        /// <summary>
        /// Executes the HTML form editor example.
        /// </summary>
        public void FillAndSubmitForm()
        {
            // Path to the sample form file (located in the test data folder)
            string formPath = Path.Combine(DataDir, "form.html");

            // Initialize an HTML document from the form file
            using (HTMLDocument document = new HTMLDocument(formPath))
            {
                // Create an instance of FormEditor
                using (FormEditor editor = FormEditor.Create(document, 0))
                {
                    // Fill individual fields
                    editor["custname"].Value = "John Doe";

                    // Save intermediate result
                    document.Save(Path.Combine(OutputDir, "filled-form.html"));

                    // Fill a textarea
                    TextAreaElement comments = editor.GetElement<TextAreaElement>("comments");
                    comments.Value = "MORE CHEESE PLEASE!";

                    // Fill multiple fields using a dictionary
                    editor.Fill(new System.Collections.Generic.Dictionary<string, string>
                    {
                        { "custemail", "john.doe@gmail.com" },
                        { "custtel", "+1202-555-0290" }
                    });

                    // Submit the form
                    using (FormSubmitter submitter = new FormSubmitter(editor))
                    {
                        SubmissionResult result = submitter.Submit();

                        if (result.IsSuccess)
                        {
                            // If the response is JSON, output the raw content
                            if (result.ResponseMessage.Headers.ContentType.MediaType == "application/json")
                            {
                                Console.WriteLine(result.Content.ReadAsString());
                            }
                            else
                            {
                                // Otherwise load the response as an HTML document
                                using (Document resultDoc = result.LoadDocument())
                                {
                                    Console.WriteLine("Form submitted successfully. Result document loaded.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Form submission failed.");
                        }
                    }
                }

                // Verify the document was processed
                Console.WriteLine($"Form document tag name: {document.DocumentElement.TagName}");
            }
        }
    }
}