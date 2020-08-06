---
title: Aspose.HTML for .NET 18.6 Release Notes
type: docs
weight: 70
url: /net/aspose-html-for-net-18-6-release-notes/
---

### **Aspose.HTML for .NET 18.6 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the June release of Aspose.HTML for .NET. In this release, we have enhanced HTML and SVG documents' Save methods. Now, you can control the process of handling resources that are linked to the document, set up restrictions and depth of saving of bound up documents.
Furthermore, we have included support for some new output formats, so you can convert your documents into Markdown notation which represents plain text format for writing structured documents, based on conventions for indicating formatting in email and usenet posts; and also save your documents into MIME Encapsulation of Aggregate HTML Documents (MHTML) format.
Another new feature that we are pleased to introduce in this release is FormEditor. It is created to simplify the work with HTML Form Elements. Since, attributes of HTML elements are represented as a 'string' objects, it is easy to make a mistake and fill the form with the wrong values. In order to avoid this mistake we introduced FormEditor which is instead of 'string' values manipulate with .net objects. Moreover, once you fill your Form up with data you can easily send it to a remote server by using a new FormSubmitter object.
### **Improvement and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1140|Construct pure HTML files|Enhancement|
|HTMLNET-1156|HTML to PNG rendering issues|Bug|
|HTMLNET-1231|Blank pages added after HTML to PDF rendition|Bug|
|HTMLNET-1205|Huge memory consumption|Bug|
### **Public API changes**
{{% alert color="primary" %}} 

This section lists public API changes that were introduced in Aspose.HTML 18.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in Aspose.HTML which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.

{{% /alert %}} 
#### **Added APIs:**
Added method RenderTo to the document to simplify rendering process
{{< highlight java >}}

 class Aspose.Html.Dom.Document

{

    /// <summary>

    /// This method is used to print the contents of the current document to the specified device.

    /// </summary>

    /// <param name="device">The user device.</param>

    public virtual void RenderTo(IDevice device){}

}

{{< /highlight >}}
Classes HTMLDocument and SVGDocument have been extended with the following list of overridden methods 'Save'
{{< highlight java >}}

 class Aspose.Html.HTMLDocument

{

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveFormat">Format in which document is saved.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, HTMLSaveFormat saveFormat){}

	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveFormat">Format in which document is saved.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, HTMLSaveFormat saveFormat){}

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveOptions">HTML save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, HTMLSaveOptions saveOptions) {}

	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveOptions">HTML save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, HTMLSaveOptions saveOptions) {}

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveOptions">Markdown save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, MarkdownSaveOptions saveOptions) {}


	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveOptions">Markdown save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, MarkdownSaveOptions saveOptions){}

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveOptions">MHTML save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, MHTMLSaveOptions saveOptions){}

	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveOptions">MHTML save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, MHTMLSaveOptions saveOptions){}

}

{{< /highlight >}}

{{< highlight java >}}

 class Aspose.Html.Dom.Svg.SVGDocument

{

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveFormat">Format in which document is saved.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, SVGSaveFormat saveFormat) {}

	/// <summary>

	/// Saves the document to local file specified by <c>path</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="path">Local path to output file.</param>

	/// <param name="saveOptions">SVG save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>path</c> is not a valid local file path.</exception>

	public void Save(string path, SVGSaveOptions saveOptions) {}

	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveFormat">Format in which document is saved.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, SVGSaveFormat saveFormat) {}

	/// <summary>

	/// Saves the document to local file specified by <c>url</c>. All resources used in this document will be saved in

	/// to adjacent folder, whose name will be constructed as: output_file_name + "_files".

	/// </summary>

	/// <param name="url">Local URL to output file.</param>

	/// <param name="saveOptions">SVG save options.</param>

	/// <exception cref="ArgumentException">Raised if the specified <c>url</c> is not a valid local file URL.</exception>

	public void Save(Url url, SVGSaveOptions saveOptions){}

}

{{< /highlight >}}
Namespace 'Aspose.Html.Saving' has respectively been extended to support new methods Save
{{< highlight java >}}

 namespace Aspose.Html.Saving

{

	/// <summary>

	/// This is an abstract base class for classes that allow the user to specify additional options when saving a document into a particular format.

	/// </summary>

	public abstract class SaveOptions

	{

		/// <summary>

		/// Gets a <see cref="Saving.ResourceHandlingOptions"/> object which is used for configuration of resources handling.

		/// </summary>

		/// <value>

		/// The <see cref="Saving.ResourceHandlingOptions"/> object.

		/// </value>

		public ResourceHandlingOptions ResourceHandlingOptions { get; }

	}

	/// <summary>

	/// Represents resource handling options.

	/// </summary>

	public class ResourceHandlingOptions

	{

		/// <summary>

		/// Gets or sets enum which represents default way of resources handling. Currently <see cref="ResourceHandling.Save"/> and <see cref="ResourceHandling.Embed"/> values are supported. Default value is <see cref="ResourceHandling.Save"/>.

		/// </summary>

		public ResourceHandling Default { get; set; }

		/// <summary>

		/// Gets or sets enum which represents the way scripts are handled. Currently <see cref="ResourceHandling.Save"/>, <see cref="ResourceHandling.Discard"/> and <see cref="ResourceHandling.Embed"/> values are supported. Default value is <see cref="ResourceHandling.Save"/>.

		/// </summary>

		public ResourceHandling JavaScript { get; set; }

		/// <summary>

		/// Gets or sets restriction applied to URLs of handled resources. Default value is <see cref="Saving.UrlRestriction.RootAndSubFolders"/>.

		/// </summary>

		public UrlRestriction UrlRestriction { get; set; }

		/// <summary>

		/// Gets or sets maximum depth of resource which will be handled. Depth of 1 means that only resources directly referenced from the saved document will be handled. Setting this property to -1 will lead to handling of all resources. Default value is 3.

		/// </summary>

		public int MaxHandlingDepth { get; set; }

	}

	/// <summary>

	/// This enum represents restriction applied to URLs of processed resources.

	/// </summary>

	public enum UrlRestriction

	{

		/// <summary>

		/// Only resources located in the root and sub folders are processed.

		/// </summary>

		RootAndSubFolders,

		/// <summary>

		/// Only resources located in the same host are processed.

		/// </summary>

		SameHost,

		/// <summary>

		/// All resources are processed.

		/// </summary>

		None

	}

	/// <summary>

	/// Specifies format in which document is saved.

	/// </summary>

	public enum HTMLSaveFormat

	{

		/// <summary>

		/// Document will be saved as HTML.

		/// </summary>

		HTML,

		/// <summary>

		/// Document will be saved as Markdown.

		/// </summary>

		Markdown,

		/// <summary>

		/// Document will be saved as MHTML.

		/// </summary>

		MHTML

	}

	/// <summary>

	/// Represents HTML save options.

	/// </summary>

	public class HTMLSaveOptions : SaveOptions

	{

	}

	/// <summary>

	/// Represents MHTML save options.

	/// </summary>

	public class MHTMLSaveOptions : SaveOptions

	{

	}

	/// <summary>

	/// Represents Markdown save options.

	/// </summary>

	public class MarkdownSaveOptions : SaveOptions

	{

		/// <summary>

		/// Flag set that controls which elements are converted to markdown.

		/// </summary>

		public MarkdownFeatures Features { get; set; }

		/// <summary>

		/// Gets or sets the markdown formatting style.

		/// </summary>

		public MarkdownFormatter Formatter { get; set; }


		/// <summary>

		/// Returns set of options which are compatible with default Markdown documentation.

		/// </summary>

		public static MarkdownSaveOptions Default { get; }

		/// <summary>

		/// Returns set of options which are compatible with GitLab Flavored Markdown.

		/// </summary>

		public static MarkdownSaveOptions Git { get; }

	}

	/// <summary>

	/// A <see cref="MarkdownFeatures"/> flag set is a set of zero or more of the following flags, which are used to select elements converted to markdown.

	/// </summary>

	[Flags]

	public enum MarkdownFeatures

	{

		/// <summary>

		/// This flag enables HTML elements inlining. If this flag is set than block level elements (such as <c>div</c>) whose <c>markdown</c> attribute value equals <c>inline</c> will be inserted in to resulting markdown.

		/// </summary>

		InlineHTML = 1,

		/// <summary>

		/// This flag enables conversion of <c>paragraph</c> elements. Content of such elements will be placed on separate lines, so markdown handlers will wrap it.

		/// </summary>

		AutomaticParagraph = 1 << 1,

		/// <summary>

		/// This flag enables conversion of <c>header</c> elements.

		/// </summary>

		Header = 1 << 2,

		/// <summary>

		/// This flag enables conversion of <c>blockquote</c> elements.

		/// </summary>

		Blockquote = 1 << 3,

		/// <summary>

		/// This flag enables conversion of <c>list</c> elements.

		/// </summary>

		List = 1 << 4,

		/// <summary>

		/// This flag enables conversion of code blocks. Code block consists of 2 elements <c>pre</c> and <c>code</c>, content of such construction is processes "as is".

		/// </summary>

		CodeBlock = 1 << 5,

		/// <summary>

		/// This flag enables conversion of <c>horizontal rules</c>.

		/// </summary>

		HorizontalRule = 1 << 6,

		/// <summary>

		/// This flag enables conversion of <c>a</c> elements.

		/// </summary>

		Link = 1 << 7,

		/// <summary>

		/// This flag enables conversion of <c>emphasis</c> elements.

		/// </summary>

		Emphasis = 1 << 8,

		/// <summary>

		/// This flag enables conversion of <c>code</c> elements.

		/// </summary>

		InlineCode = 1 << 9,

		/// <summary>

		/// This flag enables conversion of <c>img</c> elements.

		/// </summary>

		Image = 1 << 10,

		/// <summary>

		/// This flag enables conversion of <c>br</c> elements.

		/// </summary>

		LineBreak = 1 << 11,

		/// <summary>

		/// This flag enables conversion of <c>video</c> elements.

		/// </summary>

		Video = 1 << 12,

		/// <summary>

		/// This flag enables conversion of <c>table</c> elements.

		/// </summary>

		Table = 1 << 13,

		/// <summary>

		/// This flag enables conversion of task lists. Task list consists of <c>input</c> element, which must be the first child of <c>list</c> element and whose <c>type</c> attribute value should equal <c>checkbox</c>.

		/// </summary>

		TaskList = 1 << 14,

		/// <summary>

		/// This flag enables conversion of <c>del</c> elements.

		/// </summary>

		Strikethrough = 1 << 15,

		/// <summary>

		/// This flag enables conversion of <c>strong</c> elements.

		/// </summary>

		Strong = 1 << 16

	}

}

{{< /highlight >}}
Namespace Aspose.Html.Forms and following object have been introduced
{{< highlight java >}}

 namespace Aspose.Html.Forms

{

    /// <summary>

    /// This class represents the editor over the <see cref="HTMLFormElement"/> that creates a easier way for .net developers to edit the html forms.

    /// </summary>

    public class FormEditor : IEnumerable<FormElement>, IDisposable

    {

        /// <summary>

        /// Creates a new <see cref="HTMLFormElement"/> and associated it with <see cref="FormEditor"/>. <see cref="HTMLFormElement"/> is created in the detached from the document state; in order to attach it to the document, please select proper location and use <see cref="Node.AppendChild"/> method.

        /// </summary>

        /// <param name="document">The <see cref="HTMLDocument"/>.</param>

        /// <returns>Return a new instance of the <see cref="FormEditor"/> class</returns>

        public static FormEditor CreateNew(HTMLDocument document) {}

        /// <summary>

        /// Creates a new <see cref="FormEditor"/> based on <see cref="HTMLFormElement"/>.

        /// </summary>

        /// <param name="form">The html form element</param>

        /// <returns>Return a new instance of the <see cref="FormEditor"/> class</returns>

        public static FormEditor Create(HTMLFormElement form) {}

        /// <summary>

        /// Creates a new <see cref="FormEditor" /> based on <see cref="HTMLFormElement" /> selected from the <see cref="HTMLDocument.Forms"/> collection by index.

        /// </summary>

        /// <param name="document">The document.</param>

        /// <param name="index">The index inside the forms collection.</param>

        /// <exception cref="DOMException">The exception is occured if index out of the range.</exception>

        /// <returns>

        /// Return a new instance of the <see cref="FormEditor" /> class

        /// </returns>

        public static FormEditor Create(HTMLDocument document, int index) {}

        /// <summary>

        /// Creates a new <see cref="FormEditor" /> based on <see cref="HTMLFormElement" /> selected from the document by id.

        /// </summary>

        /// <param name="document">The document.</param>

        /// <param name="id">The identifier.</param>

        /// /// <exception cref="DOMException">The exception is occured if there is no element by specified Id or element is not a form type.</exception>

        /// <returns>

        /// Return a new instance of the <see cref="FormEditor" /> class

        /// </returns>

        public static FormEditor Create(HTMLDocument document, string id) {}

        /// <summary>

        /// The original <see cref="HTMLFormElement"/> that is associated with current instance of <see cref="FormEditor"/>.

        /// </summary>

        public HTMLFormElement Form { get; }

        /// <summary>

        /// The number of form controls in the form.

        /// </summary>

        public int Count { get; }

        /// <summary>

        /// HTTP method [<a href='http://www.ietf.org/rfc/rfc2616.txt'>IETF RFC 2616</a>] used to submit form. See the method attribute definition in HTML 4.01.

        /// </summary>

        public HttpMethod Method { get; set; }

        /// <summary>

        /// Server-side form handler. See the action attribute definition in HTML 4.01.

        /// </summary>

        public string Action { get; set; }

        /// <summary>

        /// Creates a new <see cref="HTMLElement"/> and adds it to the end of the form.

        /// </summary>

        /// <typeparam name="T">Type of form element</typeparam>

        /// <param name="name">Name of the element</param>

        /// <returns>A new instance of form element</returns>

        public T Add<T>(string name) where T : FormElement {}

        /// <summary>

        /// Creates a new <see cref="InputElement"/> and adds it to the end of the form.

        /// </summary>

        /// <param name="name">Name of input element</param>

        /// <returns>Returns a new created <see cref="InputElement"/>.</returns>

        public InputElement AddInput(string name)  {}

        /// <summary>

        /// Creates a new <see cref="InputElement"/> and adds it to the end of the form.

        /// </summary>

        /// <param name="name">Name of input element</param>

        /// <param name="type">Type of input element</param>

        /// <returns>Returns a new created <see cref="InputElement"/>.</returns>

        public InputElement AddInput(string name, InputElementType type) {}

        /// <summary>

        /// Returns the element by specified index.

        /// </summary>

        /// <param name="index">The index of the element</param>

        /// <returns>Returns the element.</returns>

        public FormElement this[int index] { get; }

        /// <summary>

        /// Returns the element by specified name or id.

        /// </summary>

        /// <param name="name">The element name</param>

        /// <returns>Returns the element.</returns>

        public FormElement this[string name] { get; }

        /// <summary>

        /// Returns the element by specified index.

        /// </summary>

        /// <typeparam name="T">Type of the form element</typeparam>

        /// <param name="index">The index of the element</param>

        /// <returns>Returns the element.</returns>

        public T GetElement<T>(int index) where T : FormElement {}

        /// <summary>

        /// Returns the element by specified name.

        /// </summary>

        /// <typeparam name="T">Type of the form element</typeparam>

        /// <param name="name">The element name</param>

        /// <returns>Returns the element.</returns>

        public T GetElement<T>(string name) where T : FormElement {}

        /// <summary>

        /// This method fills the whole form with the specified values.

        /// </summary>

        /// <param name="values">The values represented by key-value pair that is contains name and value for form elements.</param>

        public void Fill(Dictionary<string, string> values) {}

        /// <summary>

        /// Gets the enumerator.

        /// </summary>

        /// <returns>Returns the FormElements enumerator.</returns>

        public IEnumerator<FormElement> GetEnumerator() {}

        /// <summary>

        /// Gets the enumerator.

        /// </summary>

        /// <returns>Returns the FormElements enumerator.</returns>

        IEnumerator IEnumerable.GetEnumerator() {}

    }

	/// <summary>

    /// The <see cref="FormElement" /> represent the generic field

    /// </summary>

    /// <typeparam name="T">Type of form control elements</typeparam>

    public abstract class FormElement<T>: FormElement

        where T : HTMLElement

    {

        /// <summary>

        /// Gets the <see cref="Html.HTMLElement"/>.

        /// </summary>

        /// <value>

        /// The HTML element.

        /// </value>

        public T HtmlElement { get; }

    }

    /// <summary>

    /// Represents base class for form elements.

    /// </summary>

    public abstract class FormElement

    {

        /// <summary>

        /// Gets the type of the element.

        /// </summary>

        /// <value>

        /// The type of the element.

        /// </value>

        public FormElementType ElementType { get; }

        /// <summary>

        /// Gets or sets the name of the form element.

        /// </summary>

        /// <value>

        /// The name.

        /// </value>

        public virtual string Name { get; set; }

        /// <summary>

        /// Gets or sets the identifier of the form element.

        /// </summary>

        /// <value>

        /// The identifier.

        /// </value>

        public virtual string Id { get; set; }

        /// <summary>

        /// The value of field

        /// </summary>

        public virtual string Value { get; set; }

    }

	/// <summary>

    /// Represents an enumeration of the Form Elements types and their corresponding to the HTML Elements

    /// </summary>

    public enum FormElementType

    {

        /// <summary>

        /// Corresponding to any HTML Element that is not been converting to the any of implemented <see cref="FormElement"/>.

        /// </summary>

        Unknown = 0,

        /// <summary>

        /// Corresponding to the <see cref="HTMLInputElement"/>.

        /// </summary>

        Input = 1,

        /// <summary>

        /// Corresponding to the <see cref="HTMLSelectElement"/>.

        /// </summary>

        Select = 2,

        /// <summary>

        /// Corresponding to the <see cref="HTMLTextAreaElement"/>.

        /// </summary>

        TextArea = 3,

        /// <summary>

        /// Corresponding to the <see cref="HTMLOptionElement"/>.

        /// </summary>

        Option = 4,

    }

	/// <summary>

    /// This class allows to prepare specified <see cref="HTMLFormElement"/>, collects values from the form element, submit them to the remote server and receives a response.

    /// </summary>

    public class FormSubmitter : IDisposable

    {

        /// <summary>

        /// Initializes a new instance of the <see cref="FormSubmitter"/> class based on <see cref="HTMLFormElement"/>.

        /// </summary>

        /// <param name="form">The html form element.</param>

        public FormSubmitter(HTMLFormElement form) {}

        /// <summary>

        /// Initializes a new instance of the <see cref="FormSubmitter"/> class based on <see cref="HTMLFormElement"/> selected by index from <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="document">The HTML document.</param>

        /// <param name="index">The index of the form.</param>

        public FormSubmitter(HTMLDocument document, int index) {}

        /// <summary>

        /// Initializes a new instance of the <see cref="FormSubmitter" /> class based on <see cref="HTMLFormElement" /> selected by identifier from <see cref="HTMLDocument" />.

        /// </summary>

        /// <param name="document">The HTML document.</param>

        /// <param name="id">The element identifier.</param>

        public FormSubmitter(HTMLDocument document, string id) {}

        /// <summary>

        /// Initializes a new instance of the <see cref="FormSubmitter"/> class.

        /// </summary>

        /// <param name="editor">The FormEditor.</param>

        public FormSubmitter(FormEditor editor) {}

        /// <summary>

        /// HTTP method [<a href='http://www.ietf.org/rfc/rfc2616.txt'>IETF RFC 2616</a>] used to submit form. See the method attribute definition in HTML 4.01.

        /// </summary>

        public HttpMethod Method { get; set; }

        /// <summary>

        /// Server-side form handler. See the action attribute definition in HTML 4.01.

        /// </summary>

        public string Action { get; set; }

        #region methods

        /// <summary>

        /// Submits the form data to the server.

        /// </summary>

        /// <returns>The result of the submission.</returns>

        public SubmissionResult Submit() {}

        /// <summary>

        /// Submits the form data to the server with specified user credentials.

        /// </summary>

        /// <param name="credentials">The authentication information for the request.</param>

        /// <returns>The result of the submission.</returns>

        public SubmissionResult Submit(ICredentials credentials) {}

        /// <summary>

        /// Submits the form data to the server with specified timeout.

        /// </summary>

        /// <param name="timeout">The number of milliseconds to wait before the request times out.</param>

        /// <returns>The result of the submission.</returns>

        public SubmissionResult Submit(TimeSpan timeout) {}

        /// <summary>

        /// Submits the form data to the server with specified user credentials and timeout.

        /// </summary>

        /// <param name="credentials">The authentication information for the request.</param>

        /// <param name="timeout">The number of milliseconds to wait before the request times out.</param>

        /// <returns>The result of the submission.</returns>

        public SubmissionResult Submit(ICredentials credentials, TimeSpan timeout) {}

        /// <summary>

        /// Submits the form data to the server with specified user credentials.

        /// </summary>

        /// <param name="credentials">The authentication information for the request.</param>

        /// <param name="timeout">The number of milliseconds to wait before the request times out.</param>

        /// <param name="preAuthenticate">The value that indicates whether to send an Authorization header with the request.</param>

        /// <returns>The result of the submission.</returns>

        public SubmissionResult Submit(ICredentials credentials, TimeSpan timeout, bool preAuthenticate) {}

    }

}

{{< /highlight >}}
#### **Removed APIs:**
Namespace Aspose.Html.Dom.Css.Counters has been hidden from public API as it is not represented any useful information for users about CSS document and represents the only specialized .net wrappers over the Aspose.Html.Dom.Css.ICSSStyleRule interface. The following interfaces which are used for access to the objects from namespace Aspose.Html.Dom.Css.Counters have been hidden as well:

{{< highlight java >}}

 Aspose.Html.Services.ICssEngineService

Aspose.Html.Services.ICssService

{{< /highlight >}}
