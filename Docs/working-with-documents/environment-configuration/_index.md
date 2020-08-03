---
title: Environment Configuration
type: docs
weight: 10
url: /net/environment-configuration/
---

It is often helpful to have different configurations based on the environment where the application is running. For example, you may wish to configure the scripts policy, override document style applying a custom user stylesheet, or handle any web requests from the application. Aspose.HTML provides the [Configuration](https://apireference.aspose.com/net/html/aspose.html/configuration) object that can be used exactly for these purposes.
## **Sandboxing**
A *sandboxing flag* set is a set of zero or more of the flags, which are used to restrict the abilities that potentially untrusted resources.

The following example demonstrates how to mark ‘Scripts’ as an untrusted resource. As a result, 'Scripts' will be disabled during the application execution.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-DisableScriptsExecution.cs" >}}
## **Services**
All important functional is grouped into separated services for usability purpose and located into [Aspose.Html.Services](https://apireference.aspose.com/net/html/aspose.html.services/) namespace.
### **User Agent Service**
This service allows you to specify a custom user stylesheet, a primary character set for the document, language and fonts settings.
#### **User Style Sheet**
The user is able to specify a custom style information for a particular document. This information applies to the document according to the [cascading rules](https://www.w3.org/TR/css-cascade-3/#cascading-origins) and may affect the presentation of the document. The next code snippet shows how to use the UserStyleSheet property:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-SpecifyUserStyleSheet.cs" >}}
#### **Character Set**
In order to parse and display an HTML document correctly, the application must know what character-set (encoding) is using for the document. If the character encoding is not directly specified in the header of the document, Aspose.HTML uses UTF-8, which is defined as the default for HTML5 specification. However, if you are sure that your HTML document is written using different from UTF-8 encoding, you can specify it manually, as it follows.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-SpecifyCharacterSet.cs" >}}
#### **Set Path to the Font Folder**
For a situation when you need to use the custom fonts instead of the fonts installed on OS, you can set the path to your custom folder, as it follows.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-SpecifyFontFolder.cs" >}}
### **Runtime Service**
This service gives you control over the lifetime of the internal processes. For instance, using [IRuntimeService](https://apireference.aspose.com/net/html/aspose.html.services/iruntimeservice) you can specify timeouts for JavaScripts. It is important to have such a timeout in case if a script contains an endless loop. The next code snippet demonstrates how to use timeouts.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-JavaScriptExecutionTimeout.cs" >}}
### **Network Service**
[INetworkService](https://apireference.aspose.com/net/html/aspose.html.services/inetworkservice) allows you to control all incoming/outcoming traffic and implement your custom message handlers. It can be used for different purposes, such as: create custom caching mechanism, trace/logging request messages, etc.
#### **Message Handlers**
The following example demonstrates how to use message handlers to log information about unreachable resources. First of all, you need to create a custom message handler:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-LogMessageHandler.cs" >}}

and use it, as it follows:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-EnvironmentConfiguration-CustomMessageHandler.cs" >}}
