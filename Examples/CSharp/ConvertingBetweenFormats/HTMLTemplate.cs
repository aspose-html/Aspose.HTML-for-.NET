using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class HTMLTemplate
    {
        public static void CreateHTMLFromTemplate()
        {
            //ExStart: CreateHTMLFromTemplate
            // Prepare a JSON data-source and save it to the file.
            var data = @"{
                'FirstName': 'John',
                'LastName': 'Smith',
                'Address': {
                    'City': 'Dallas',
                    'Street': 'Austin rd.',
                    'Number': '200'
                    }
                }";
            System.IO.File.WriteAllText("data-source.json", data);

            // Prepare an HTML Template and save it to the file.
            var template = @"
                <table border=1>
                    <tr>
                        <th>Person</th>
                        <th>Address</th>
                    </tr>
                    <tr>
                        <td>{{FirstName}} {{LastName}}</td>
                        <td>{{Address.Street}} {{Address.Number}}, {{Address.City}}</td>
                    </tr>
                </table>
                ";
            System.IO.File.WriteAllText("template.html", template);

            // Invoke Converter.ConvertTemplate in order to populate 'template.html' with the data-source from 'data-source.json' file
            Aspose.Html.Converters.Converter.ConvertTemplate("template.html", new Aspose.Html.Converters.TemplateData("data-source.json"), new Aspose.Html.Loading.TemplateLoadOptions(), "document.html");
            //ExEnd: CreateHTMLFromTemplate
        }
    }
}
