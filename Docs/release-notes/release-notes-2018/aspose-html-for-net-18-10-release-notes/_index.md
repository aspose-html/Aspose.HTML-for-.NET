---
title: Aspose.HTML for .NET 18.10 Release Notes
type: docs
weight: 30
url: /net/aspose-html-for-net-18-10-release-notes/
---

### **Aspose.HTML for .NET 18.10 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce October release of Aspose.HTML for .NET. The main improvement of this release is that we have created a truly parallel mechanism of processing the documents that significantly improved performance of processing documents with lots of resources. Moreover, from this moment you do not need to wait until document will be loaded, parsed and all scripts will be executed which of course is blocking the main thread of your application. You just need to subscribe to events the 'OnReadyStateChange' or 'OnLoad' and call the method 'navigate' which is not blocking the main thread. Once the document is ready, these events will be fired. Also, we represent to you a new namespace 'Aspose.Html.Dom.Mutations' that provides mechanisms to watch for changes being made to DOM tree. Apart from that, we have also made some internal bug fixes and enhancements as in the table below.
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1457|Text alignment issues with Arabic in table cells|Bug|
|HTMLNET-1499|HTML to XPS: Incorrect Woff signature exception|Bug|
|HTMLNET-1507|Font-size "em"-values in at-page rules cause an exception|Bug|
### **Added APIs:**
The document object has been extended with set of overloaded methods Navigate, that are create an asynchronous mode of loading unlike the HTMLDocument and SVGDocument constructors which are working in synchronous mode.

{{< highlight java >}}

 namespace Aspose.Html.Dom

{

    public class Document

    {

        /// <summary>

        /// Loads the document at the specified Uniform Resource Locator (URL) into the current instance, replacing the previous content.

        /// </summary>

        /// <param name="address">The document address.</param>

        public void Navigate(string address) {}

        /// <summary>

        /// Loads the document at the specified Uniform Resource Locator (URL) into the current instance, replacing the previous content.

        /// </summary>

        /// <param name="url">The document URL.</param>

        public void Navigate(Url url) {}

        /// <summary>

        /// Loads the document from specified content and using baseUri to resolve relative resources, replacing the previous content.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI to resolve relative resources.</param>

        public void Navigate(string content, string baseUri) {}

        /// <summary>

         /// Loads the document from specified content and using baseUri to resolve relative resources, replacing the previous content.

         /// </summary>

         /// <param name="content">The document content.</param>

         /// <param name="baseUri">The base URI to resolve relative resources.</param>

        public void Navigate(Stream content, string baseUri) {}

        /// <summary>

        /// Loads the document based on specified request object, replacing the previous content.

        /// </summary>

        /// <param name="request">The request object that is used to load document content.</param>

        public void Navigate(RequestMessage request) {}

    }

}

{{< /highlight >}}

Added event OnReadyStateChange and ReadyState property in order to inform the user about document's readiness state.

{{< highlight java >}}

 namespace Aspose.Html.Dom

{

    public class Document

    {

        /// <summary>

        /// Gets or sets event handler for OnReadyStateChange event.

        /// </summary>

        public event DOMEventHandler OnReadyStateChange;

        /// <summary>

        /// Returns the document readiness. The "loading" while the Document is loading, "interactive" once it is finished parsing but still loading sub-resources, and "complete" once it has loaded.

        /// </summary>

        public string ReadyState { get; }

    }

}

{{< /highlight >}}

Introduced the Dom.Mutations namespace that provides mechanisms to watch for changes being made to the DOM tree.

{{< highlight java >}}

 namespace Aspose.Html.Dom.Mutations

{

    /// <summary>

    /// Represents the method that will handle a mutation events.

    /// </summary>

    /// <param name="mutations">The list of mutation records.</param>

    /// <param name="observer">The mutation observer.</param>

    public delegate void MutationCallback(IList<MutationRecord> mutations, MutationObserver observer);

    /// <summary>

    /// A <see cref="MutationObserver" /> object can be used to observe mutations to the tree of <see cref="Node" />.

    /// </summary>

    public class MutationObserver

    {

        /// <summary>

        /// Constructs a MutationObserver object and sets its <see cref="MutationCallback"/> to callback.

        /// The callback is invoked with a list of MutationRecord objects as first argument and the constructed MutationObserver object as second argument. It is invoked after nodes registered with the <see cref="Observe(Node, IMutationObserverInit)"/> method, are mutated.

        /// </summary>

        /// <param name="callback">The callback.</param>

        public MutationObserver(MutationCallback callback) {}

        /// <summary>

        /// Instructs the user agent to observe a given target (a node) and report any mutations based on the criteria given by options (an object).

        /// The options argument allows for setting mutation observation options via object members.

        /// </summary>

        /// <param name="target">The target for observe.</param>

        /// <param name="options">The observer options.</param>

        public void Observe(Node target, MutationObserverInit options) {}

        /// <summary>

        /// Stops observer from observing any mutations. Until the observe() method is used again, observer’s callback will not be invoked.

        /// </summary>

        public void Disconnect() {}

        /// <summary>

        /// The method returns a copy of the record queue and then empty the record queue.

        /// </summary>

        /// <returns>The copy of the record queue.</returns>

        public IEnumerable<MutationRecord> TakeRecords() {}

    }

    /// <summary>

    /// The IMutationObserverInit interface represents an options for mutation observation. The options argument allows for setting mutation observation options via object members.

    /// </summary>

    public struct MutationObserverInit

    {

        /// <summary>

        /// Set to true if mutations to target’s children are to be observed.

        /// </summary>

        public bool ChildList { get; set; }

        /// <summary>

        /// Set to true if mutations to target’s attributes are to be observed. Can be omitted if attributeOldValue and/or attributeFilter is specified.

        /// </summary>

        public bool Attributes { get; set; }

        /// <summary>

        /// Set to true if mutations to target’s data are to be observed. Can be omitted if characterDataOldValue is specified

        /// </summary>

        public bool CharacterData { get; set; }

        /// <summary>

        /// Set to true if mutations to not just target, but also target’s descendants are to be observed

        /// </summary>

        public bool Subtree { get; set; }

        /// <summary>

        /// Set to true if attributes is true or omitted and target’s attribute value before the mutation needs to be recorded.

        /// </summary>

        public bool AttributeOldValue { get; set; }

        /// <summary>

        /// Set to true if characterData is set to true or omitted and target’s data before the mutation needs to be recorded.

        /// </summary>

        public bool CharacterDataOldValue { get; set; }

        /// <summary>

        /// Set to a list of attribute local names (without namespace) if not all attribute mutations need to be observed and attributes is true or omitted.

        /// </summary>

        public IList<string> AttributeFilter { get; set; }

    }

    /// <summary>

    /// A MutationRecord represents an individual DOM mutation. It is the object that is passed to <see cref="MutationObserver"/>'s <see cref="MutationCallback"/>.

    /// </summary>

    public class MutationRecord

    {

        /// <summary>

        /// Initializes a new instance of the <see cref="MutationRecord" /> class.

        /// </summary>

        /// <param name="type">The type.</param>

        /// <param name="target">The target.</param>

        /// <param name="addedNodes">The added nodes.</param>

        /// <param name="removedNodes">The removed nodes.</param>

        /// <param name="previousSibling">The previous sibling.</param>

        /// <param name="nextSibling">The next sibling.</param>

        /// <param name="attributeName">Name of the attribute.</param>

        /// <param name="attributeNamespace">The attribute namespace.</param>

        /// <param name="oldValue">The old value.</param>

        internal MutationRecord(string type, Node target, IList<Node> addedNodes, IList<Node> removedNodes,  Node previousSibling, Node nextSibling, string attributeName, string attributeNamespace, string oldValue) {}

        /// <summary>

        /// Returns "attributes" if it was an attribute mutation, "characterData" if it was a mutation to a CharacterData node and "childList" if it was a mutation to the tree of nodes.

        /// </summary>

        /// <value>

        /// The type.

        /// </value>

        public string Type { get; }

        /// <summary>

        /// Returns the node the mutation affected, depending on the type. For "attributes", it is the element whose attribute changed. For "characterData", it is the CharacterData node. For "childList", it is the node whose children changed.

        /// </summary>

        /// <value>

        /// The target.

        /// </value>

        public Node Target { get; }

        /// <summary>

        /// Return the nodes added.

        /// </summary>

        /// <value>

        /// The added nodes.

        /// </value>

        public IList<Node> AddedNodes { get; }

        /// <summary>

        /// Return the nodes removed.

        /// </summary>

        /// <value>

        /// The removed nodes.

        /// </value>

        public IList<Node> RemovedNodes { get; }

        /// <summary>

        /// Returns the previous sibling of the added or removed nodes, or null.

        /// </summary>

        /// <value>

        /// The previous sibling.

        /// </value>

        public Node PreviousSibling { get; }

        /// <summary>

        /// Return the next sibling of the added or removed nodes, or null.

        /// </summary>

        /// <value>

        /// The next sibling.

        /// </value>

        public Node NextSibling { get; }

        /// <summary>

        /// Returns the local name of the changed attribute, and null otherwise.

        /// </summary>

        /// <value>

        /// The name of the attribute.

        /// </value>

        public string AttributeName { get; }

        /// <summary>

        /// Returns the namespace of the changed attribute, and null otherwise.

        /// </summary>

        /// <value>

        /// The attribute namespace.

        /// </value>

        public string AttributeNamespace { get; }

        /// <summary>

        /// The return value depends on type. For "attributes", it is the value of the changed attribute before the change.

        /// For "characterData", it is the data of the changed node before the change.

        /// For "childList", it is null.

        /// </summary>

        /// <value>

        /// The old value.

        /// </value>

        public string OldValue { get; }

    }

}

{{< /highlight >}}

The abstract renderer object was extended with overload 'render' methods in order to add ability to control rendering timeouts.

{{< highlight java >}}

 namespace Aspose.Html.Rendering

{

    public abstract class Renderer<TDocument> : Renderer

    {

        /// <summary>

        /// Defines method for rendering <see cref="TDocument" /> into specified <see cref="IDevice" />.

        /// The rendering will be performed once there are no any network operations for loading resources, active timers, animation tasks or specified timeout is elapsed.

        /// </summary>

        /// <param name="device">The output device.</param>

        /// <param name="document">The document.</param>

        /// <param name="timeout">A <see cref="TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="TimeSpan" /> that represents -1 millisecond to wait indefinitely.</param>

        public void Render(IDevice device, TDocument document, TimeSpan timeout) {}

        /// <summary>

        /// Defines method for rendering <see cref="TDocument" /> into specified <see cref="IDevice" />.

        /// The rendering will be performed once there are no any network operations for loading resources, active timers, animation tasks or specified timeout is elapsed.

        /// </summary>

        /// <param name="device">The output device.</param>

        /// <param name="document">The document.</param>

        /// <param name="timeout">A number of milliseconds that represents the number of milliseconds to wait, or -1 millisecond to wait indefinitely.</param>

        public void Render(IDevice device, TDocument document, int timeout) {}

        /// <summary>

        /// Defines method for rendering multiple <see cref="TDocument" />s into specific <see cref="IDevice" />.

        /// The rendering will be performed once there are no any network operations for loading resources, active timers, animation tasks or specified timeout is elapsed.

        /// </summary>

        /// <param name="device">The output device.</param>

        /// <param name="timeout">A number of milliseconds that represents the number of milliseconds to wait, or -1 millisecond to wait indefinitely.</param>

        /// <param name="documents">The documents to render.</param>

        public void Render(IDevice device, int timeout, params TDocument[] documents) {}

        /// <summary>

        /// Defines method for rendering multiple <see cref="TDocument" />s into specific <see cref="IDevice" />.

        /// The rendering will be performed once there are no any network operations for loading resources, active timers, animation tasks or specified timeout is elapsed.

        /// </summary>

        /// <param name="device">The output device.</param>

        /// <param name="timeout">A <see cref="TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="TimeSpan" /> that represents -1 millisecond to wait indefinitely.</param>

        /// <param name="documents">The documents to render.</param>

        public abstract void Render(IDevice device, TimeSpan timeout, params TDocument[] documents);

    }

}

{{< /highlight >}}
#### **Changed APIs:**
StyleSheets property was relocated to the base 'document' class from the HTML and SVG documents.

{{< highlight java >}}

 namespace Aspose.Html.Dom

{

    public class Document

    {

        /// <summary>

        /// A list containing all the style sheets explicitly linked into or embedded in a document. For HTML documents, this includes external style sheets, included via the HTML LINK element, and inline STYLE elements.

        /// </summary>

        public IStyleSheetList StyleSheets { get; }

    }

}

{{< /highlight >}}
