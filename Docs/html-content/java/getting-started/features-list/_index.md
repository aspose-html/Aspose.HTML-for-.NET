---
title: Features List
type: docs
weight: 30
url: /java/features-list/
---

{{% alert color="primary" %}} 

The following table summarizes the features available in Aspose.HTML for Java API.

{{% /alert %}} 
## **Aspose.HTML for Java Features**
Aspose.HTML is a programming API that allows developers to create, open existing, manipulate, navigate through and convert (X)HTML documents into the various supported output formats. Aspose.HTML implements W3C HTML specification, so it’s classes and properties have similar names that come from the specifications.



This API mimics the behavior of a headless browser and offers following features.

- Creating or opening an existing HTML document from different sources (Aspose.HTML.Examples.QuickStart.DocumentOpenTests in the examples project);
- HTML Manipulation: creating, editing, removing and replacing HTML nodes via API 
- Saving HTML document
- Extracting CSS styles for particular HTML node
- Configuring a document sandbox that affects the processing of HTML documents i.e. CSS styles in some cases are [dependent on screen size](https://www.w3.org/TR/css3-mediaqueries/#width) and we allow to configure environment independently of an execution machine
- Navigation through HTML document in different ways:
  - by using [Element Traversal](https://www.w3.org/TR/ElementTraversal)
  - by using [Document Traversal](https://www.w3.org/TR/DOM-Level-2-Traversal-Range/traversal.html)
  - by using [XPath queries](https://www.w3.org/TR/xpath)
  - by using [CSS Selector queries](https://www.w3.org/TR/selectors-api)
- Scripting that allows to manipulate HTML DOM via JavaScript
- Converting HTML document into various supported formats: JPEG, PNG, BMP, TIFF, PDF, XPS
- Converting (X)HTML and similar formats, such as ePub and MHTML to above specified formats.

Note

- String representation of[ CSS Color value](https://www.w3.org/TR/cssom-1/#serialize-a-css-component-value) is dependent of the context that can be either in a ‘specified’ or ‘computed’ state.
  - In the ‘computed’ state CSS Color is represented as rgb/rgba function.
  - In the ‘specified’ state CSS Color is represented as original string specified by the author.

The URL object is based on Java Framework implementation according to w3c URL specification. The difference between Framework and w3c is an order of [constructor parameters](https://url.spec.whatwg.org/#dom-url-url)
### **General Features**
- Written completely in Java and works with JRE.
- JDK environment required.
- Supports Desktop, JSP or JSP applications.
- API reference in HTML and Microsoft Help format.
- Supported JDK 1.6 or higher versions.
- 32-bit OS support.
- 64-bit OS support.
### **Supported HTML versions**
Aspose.HTML for Java supports HTML and (X)HTML.
### **Namespaces structure in API**
![todo:image_alt_text](https://lh3.googleusercontent.com/9k_uvN_5kZ4tJ2S0a409a1FqSSrVdciYq2DOia3mB4sLPdmt5GPI_9BnO--3r6UtOl_YI0nx8AksMcIJ6YrkcegSqbzaz53Qj3xybqWfVnizMO_pbA3VjcR2ZgszWpV_IclR41pf)
### **Text**
- Extract text from pages.
- Search text from pages.
- Add text in HTML file.
### **Document**
- Create, edit, remove and replace HTML nodes
- Extracting CSS styles for particular HTML node
- Convert HTML documents into various supported image formats: JPEG, PNG, BMP, TIFF
- Convert HTML documents to PDF format
- Convert HTML documents to XPS format






