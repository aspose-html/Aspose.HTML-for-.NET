---
title: HTML Template
type: docs
weight: 160
url: /net/html-template/
---

This article describes how to create an HTML document based on a template and populate it from a data-source. Aspose.HTML provides the inline expressions syntax to work with templates and various types of data-source, such as XML and JSON.
## **Template markup**
The HTML template is a regular HTML file that contains some special inline expressions that specify the input data-source mapping to the HTML page markup. These inline expressions use double curled bracket notation. During the template processing, the template markers will be replaced with respective data values following the rules described below.
### **Inline expressions**
Following is the list of supported inline expressions syntax.
#### **{{ ... }} - data-binding expression**
The *data-binding expression* is used to set values of control element based on the information that is contained in the data-source. 

The following is the basic syntax of the data-binding expression:

{{ data-binding expression  }}

The following demo shows how to use the data-binding expression to obtain information from the XML data-source.

**XML Data Source**

{{< highlight html >}}

 <Data>

    <FirstName>John</FirstName>

    <LastName>Smith</LastName>

    <Address>

        <City>Dallas</City>

        <Street>Austin rd.</Street>

        <Number>200</Number>

    </Address>

</Data>

{{< /highlight >}}

The data-binding expression in the HTML page template:

**HTML Template**

{{< highlight html >}}

 <Data>

    <FirstName>John</FirstName>

    <LastName>Smith</LastName>

    <Address>

        <City>Dallas</City>

        <Street>Austin rd.</Street>

        <Number>200</Number>

    </Address>

</Data>

{{< /highlight >}}
#### **{{#foreach ... }} - foreach directive expression**
The *foreach directive expression* is used to iterate through the list of elements in combination with *data-binding expression*.

The following demo shows how to get all persons from the data-source and populate a template:

**XML Data Source**

{{< highlight html >}}

 <Data>

      <Persons>

            <Person>

                  <FirstName>John</FirstName>

                  <LastName>Smith</LastName>

                  <Address>

                         <Number>200</Number>

                         <Street>Austin rd.</Street>

                         <City>Dallas</City>

                   </Address>

                   <Phone1>345-345-34-55</Phone1>

                   <Phone2>345-555-09-09</Phone2>

            </Person>

            <Person>

                   <FirstName>Jack</FirstName>

                   <LastName>Fox</LastName>

                   <Address>

                         <Number>25</Number>

                         <Street>Broadway</Street>

                         <City>New York</City>

                   </Address>

                   <Phone1>081-544-12-15</Phone1>

             </Person>

             <Person>

                   <FirstName>Sherlock</FirstName>

                   <LastName>Holmes</LastName>

                   <Address>

                         <Number>65</Number>

                         <Street>Baker str.</Street>

                         <City>London</City>

                    </Address>

                    <Phone1>012-5344-334</Phone1>

            </Person>

      </Persons>

</Data>

{{< /highlight >}}

The *foreach directive expression* in the HTML page template:

**HTML Template**

{{< highlight html >}}

 <table border=1 data_merge='{{#foreach Persons.Person}}'>

    <tr>

        <th>Person</th>

        <th>Address</th>

    </tr>

    <tr>

        <td>{{FirstName}} {{LastName}}</td>

        <td>{{Address.Street}} {{Address.Number}}, {{Address.City}}</td>

    </tr>

</table>

{{< /highlight >}}

{{% alert color="primary" %}} 

Please note that the current implementation supports *foreach directive expression* only for the following list of HTML elements: DIV, OL, UL and TABLE.

{{% /alert %}} 
## **Data Source**
As it was mentioned earlier, the data-source could be represented in XML and JSON formats. The following are the examples of both data-source that prepared for this article:

**XML Data Source**

{{< highlight html >}}

 <Data>

    <FirstName>John</FirstName>

    <LastName>Smith</LastName>

    <Address>

        <City>Dallas</City>

        <Street>Austin rd.</Street>

        <Number>200</Number>

    </Address>

</Data>

{{< /highlight >}}

**JSON Data Source**

{{< highlight javascript >}}

 {

    'FirstName': 'John',

    'LastName': 'Smith',

    'Address': {

        'City': 'Dallas',

        'Street': 'Austin rd.', 

        'Number': '200'

    }

}

{{< /highlight >}}
## **Usage Example**
Once you have prepared an HTML Template, you can convert Template to HTML in your C# application literally with a single line of code!

Please note that you can use [**TemplateLoadOptions.NamesAreCaseSensitive**](https://apireference.aspose.com/net/html/aspose.html.loading/templateloadoptions/properties/namesarecasesensitive) property to define whether the template and data element names will be matched regardless of the character case or not.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-HTMLTemplate-CreateHTMLFromTemplate.cs" >}}
