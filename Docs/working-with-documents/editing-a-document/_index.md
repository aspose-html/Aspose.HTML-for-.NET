---
title: Editing a Document
type: docs
weight: 30
url: /net/editing-a-document/
---

As we already mentioned [here](/html/net/creating-a-document/) the implementation of [HTMLDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument) as well as the whole DOM are based on [WHATWG DOM](https://dom.spec.whatwg.org/) standard. So, it is easy to use Aspose.HTML having a basic knowledge of [HTML](https://en.wikipedia.org/wiki/HTML) and [JavaScript](https://en.wikipedia.org/wiki/JavaScript) languages.
The [DOM namespace](https://apireference.aspose.com/net/html/aspose.html.dom/) is represented with the following fundamental data types:

|**Data type** |**Description**|
| :- | :- |
|[Document](https://apireference.aspose.com/net/html/aspose.html.dom/document)|The Document represents the entire HTML, XML or SVG document. Conceptually, it is the root of the document tree and provides the primary access to the document's data.|
|[EventTarget](https://apireference.aspose.com/net/html/aspose.html.dom/eventtarget)|The *EventTarget* interface is implemented by all Nodes in an implementation that supports the *DOM Event Model*.|
|[Node](https://apireference.aspose.com/net/html/aspose.html.dom/node)|The *Node* is the primary datatype for the entire *Document Object Model*. It represents a single node in the document tree.|
|[Element](https://apireference.aspose.com/net/html/aspose.html.dom/element)|The element type is based on node and represents a base class for *HTML*, *XML* or *SVG DOM.*|
|[Attribute](https://apireference.aspose.com/net/html/aspose.html.dom/attr)|The *Attr* interface represents an attribute in an Element object. Typically the allowable values for the attribute are defined in a schema associated with the document.|

The following is a brief list of useful API methods provides by the core data types:

|**Method** |**Description**|
| :- | :- |
|[document.getElementById(elementId)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/getelementbyid) |The method, when invoked, must return the first element whose ID is elementId and null if there is no such element otherwise.|
|[document.getElementsByTagName(name) ](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/getelementsbytagname)|The method must return the list of elements with the given name.|
|[document.createElement(tagName)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createelement)|The method creates the HTML element specified by tagName, or an [HTMLUnknownElement](https://apireference.aspose.com/net/html/aspose.html/htmlunknownelement) if tagName isn't recognized.|
|[parentNode.appendChild(node)](https://apireference.aspose.com/net/html/aspose.html.dom/node/methods/appendchild)|The method adds a node to the end of the list of children of a specified parent node.|
|[element.setAttribute(name, value)](https://apireference.aspose.com/net/html/aspose.html.dom/element/methods/setattribute)|Sets the value of an attribute on the specified element.|
|[element.getAttribute(name)](https://apireference.aspose.com/net/html/aspose.html.dom/element/methods/getattribute)|The method returns the value of a specified attribute on the element.|
|[element.innerHTML](https://apireference.aspose.com/net/html/aspose.html.dom/element/properties/innerhtml) |Returns a fragment of markup contained within the element.|

For a complete list of interfaces and methods represented in the DOM namespace please visit [API Reference Source](https://apireference.aspose.com/net/html/aspose.html.dom/).
## **Edit HTML**
There are many ways you can edit HTML by using our library. You can modify the document by inserting new nodes, removing, or editing the content of existing nodes. If you need to create a new node, the following methods are ones that need to be invoked:

|**Method** |**Description** |
| :- | :- |
|[document.CreateCDATASection(data)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createcdatasection) |Creates a CDATASection node whose value is the specified string. |
|[document.CreateComment(data)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createcomment) |Creates a Comment node given the specified string. |
|[document.CreateDocumentFragment()](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createdocumentfragment) |Creates an empty DocumentFragment object. |
|[document.CreateElement(localName)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createelement) |Creates an element of the type specified. |
|[document.CreateEntityReference(name)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createentityreference) |Creates an EntityReference object. |
|[document.CreateProcessingInstruction(target, data)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createprocessinginstruction) |Creates an ProcessingInstruction with the specified name and data. |
|[document.CreateTextNode(data)](https://apireference.aspose.com/net/html/aspose.html.dom/document/methods/createtextnode) |Creates a Text node given the specified string. |


Once you have new nodes are created, there are several methods in DOM that can help you to insert nodes into the tree. The following list describes the most common way of inserting nodes: 

|**Method** |**Description** |
| :- | :- |
|[node.InsertBefore(node, child)](https://apireference.aspose.com/net/html/aspose.html.dom/node/methods/insertbefore) |Inserts the node before the reference *child* node|
|[node.AppendChild(node)](https://apireference.aspose.com/net/html/aspose.html.dom/node/methods/appendchild) |Adds the node to the list of children of the current node |
To remove a node from the HTML DOM tree, please use the [RemoveChild(child)](https://apireference.aspose.com/net/html/aspose.html.dom/node/methods/removechild) or [Remove()](https://apireference.aspose.com/net/html/aspose.html.dom/node/methods/removechild) methods.



The following is a code snippet how to edit HTML document using the mentioned above functional:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EditingADocument-UsingDOM.cs" >}}
## **Using InnerHTML & OuterHTML attributes**
Having DOM objects gives you a powerful tool to manipulate with an HTML Document. However, sometime much better to work just with [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.8). The following code snippet shows you how to use [InnerHTML](https://apireference.aspose.com/net/html/aspose.html.dom/element/properties/innerhtml) & [OuterHTML](https://apireference.aspose.com/net/html/aspose.html.dom/element/properties/outerhtml) properties to edit HTML.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EditingADocument-UsingInnerOuterHTML.cs" >}}
## **Edit CSS**
[Cascading Style Sheets (CSS)](https://en.wikipedia.org/wiki/Cascading_Style_Sheets) is a style sheet language used for describing how webpages look in the browser. Aspose.HTML not only support CSS out-of-the-box but also gives you instruments to manipulate with document styles just on the fly before converting the HTML document to the other formats, as it follows:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EditingADocument-EditCSS.cs" >}}
