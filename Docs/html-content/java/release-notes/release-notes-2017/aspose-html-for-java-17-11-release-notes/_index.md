---
title: Aspose.Html for Java 17.11 Release Notes
type: docs
weight: 20
url: /java/aspose-html-for-java-17-11-release-notes/
---

As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the November release of Aspose.HTML for Java. In this release, we have:

- Introduced 'live' and 'static' collections of HTML nodes according to HTML Traversal recommendation.
- Improved the transport layer of our library that allows to read the document encoding from the web requests/response.
- Introduced PdfPermissions enumeration for configuring Aspose.Html.Rendering.Pdf.Encryption object.

We have made some internal bug fixes and also made improvements to Document Traversal and network layer. Furthermore, we have added Enumeration to make our interfaces, which are related to rendering into PdfDevice which is similar to Aspose.Pdf.
### **Public API Changes**
#### **Added APIs**
Enumeration: com.aspose.html.rendering.pdf.encryption.PdfPermissions
#### **Edit APIs**
HTMLCollection com.aspose.html.dom.Element.QuerySelectorAll(String selector)

// has been replaced with

NodeList com.aspose.html.dom.Element.QuerySelectorAll(String selector)



HTMLCollection com.aspose.html.dom.Document.QuerySelectorAll(String selector)

// has been replaced with

NodeList com.aspose.html.dom.Document.QuerySelectorAll(String selector)



com.aspose.html.rendering.pdf.Encryption(String userPassword, String ownerPassword, int permissions, PdfEncryptionAlgorithm encryptionAlgorithm)

// has been replaced with

com.aspose.html.rendering.pdf.Encryption(String userPassword, String ownerPassword, PdfPermissions permissions, PdfEncryptionAlgorithm encryptionAlgorithm)
