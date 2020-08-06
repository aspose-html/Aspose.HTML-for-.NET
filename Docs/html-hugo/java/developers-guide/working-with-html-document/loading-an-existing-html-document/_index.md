---
title: Loading an existing HTML document
type: docs
weight: 10
url: /java/loading-an-existing-html-document/
---

## **Loading an existing HTML document**
The Aspose.HTML for Java provides the capabilities to create as well as manipulate existing HTML files. The HTML file can be loaded from certain path over file system or can be accessed through URL. The following code lines show how to create a simple HTML document containing one paragraph element.



{{< gist "aspose-html" "27c911964bab73c47ca41f154bb7a682" "Examples-src-main-java-com-aspose-html-examples-document-LoadHtmlDoc-LoadHtmlDoc.java" >}}

The com.aspose.html package has a class named HTMLDocument which provides the capabilities to create or load any existing HTML document. This class has an object Body which contains the contents of the document and while using this object, we can access further sub elements inside the Body object. The following code snippet shows the steps to read Inner HTML. The HTML file is loaded from certain path of file system.



{{< gist "aspose-html" "27c911964bab73c47ca41f154bb7a682" "Examples-src-main-java-com-aspose-html-examples-document-ReadInnerHtml-ReadInnerHtml.java" >}}

The com.aspose.html package also has a class named Url which specifies the URL for input HTML file. You can provide path from where HTML file needs to be loaded or provide BaseUrl and RelativeUrl to load the required document.



{{< gist "aspose-html" "27c911964bab73c47ca41f154bb7a682" "Examples-src-main-java-com-aspose-html-examples-document-LoadHtmlUsingURL-LoadHtmlUsingURL.java" >}}

The HTML file can also be loaded from a remote URL / server. All we need to do is to provide the URL of remote server as an argument to **com.aspose.html.Url** object. Once the HTML file is loaded, we can get an access to ChildNodes inside Body object, we can get the information regarding BaseUrl and also the domain over which the HTML file is hosted.



{{< gist "aspose-html" "27c911964bab73c47ca41f154bb7a682" "Examples-src-main-java-com-aspose-html-examples-document-LoadHtmlUsingRemoteServer-LoadHtmlUsingRemoteServer.java" >}}








