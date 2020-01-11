using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Document
{
    class EditDocument
    {
        public static void Run()
        {
            EditDocumentTree();
            EditDocumentTreeWithAppendRemoveChild();
            EditHtml();
            EditElementStyleUsingAttribute();
        }

        private static void EditDocumentTree()
        {
            //ExStart: EditDocumentTree
            using (var document = new Aspose.Html.HTMLDocument())
            {
                var body = document.Body;

                // Create paragraph element
                var p = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");

                // Set custom attribute
                p.SetAttribute("id", "my-paragraph");

                // Create text node
                var text = document.CreateTextNode("my first paragraph");

                // Attach text to the paragraph
                p.AppendChild(text);

                // Attach paragraph to the document body
                body.AppendChild(p);
            }
            //ExEnd: EditDocumentTree
        }

        private static void EditDocumentTreeWithAppendRemoveChild()
        {
            //ExStart: EditDocumentTreeWithAppendRemoveChild
            using (var document = new Aspose.Html.HTMLDocument("<p>paragraph</p><div>some element to remove</div>", "about:blank"))
            {
                var body = document.Body;

                // Get "div" element
                var div = (Aspose.Html.HTMLDivElement)body.GetElementsByTagName("div").First();

                // Remove found element
                body.RemoveChild(div);
            }
            //ExEnd: EditDocumentTreeWithAppendRemoveChild
        }

        private static void EditHtml()
        {
            //ExStart: EditHtml
            using (var document = new Aspose.Html.HTMLDocument())
            {
                // Get body element
                var body = document.Body;

                // Set content of the body element
                body.InnerHTML = "<p>paragraph</p>";

                // Move to the first child
                var node = body.FirstChild;
                System.Console.WriteLine(node.LocalName);
            }
            //ExEnd: EditHtml
        }

        private static void EditElementStyle()
        {
            //ExStart: EditElementStyle
            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: red; }</style><p>my first paragraph</p>", "about:blank"))
            {
                // Get the element to inspect
                var element = document.GetElementsByTagName("p")[0];

                // Get the CSS view object
                var view = (Aspose.Html.Dom.Css.IViewCSS)document.Context.Window;

                // Get the computed style of the element
                var declaration = view.GetComputedStyle(element);

                // Get "color" property value
                System.Console.WriteLine(declaration.Color); // rgb(255, 0, 0)
            }
            //ExEnd: EditElementStyle
        }

        private static void EditElementStyleUsingAttribute()
        {
            //ExStart: EditElementStyleUsingAttribute
            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: red; }</style><p>my first paragraph</p>", "about:blank"))
            {
                // Get the element to edit
                var element = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];

                // Get the CSS view object
                var view = (Aspose.Html.Dom.Css.IViewCSS)document.Context.Window;

                // Get the computed style of the element
                var declaration = view.GetComputedStyle(element);

                // Set green color
                element.Style.Color = "green";

                // Get "color" property value
                System.Console.WriteLine(declaration.Color); // rgb(0, 128, 0)
            }
            //ExEnd: EditElementStyleUsingAttribute
        }
    }
}
