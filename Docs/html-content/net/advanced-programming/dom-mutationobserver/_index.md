---
title: DOM MutationObserver
type: docs
weight: 30
url: /net/dom-mutationobserver/
---

A document observation mechanism is represented with [MutationObserver](https://apireference.aspose.com/net/html/aspose.html.dom.mutations/mutationobserver), that is easy to configure, and it is used to register listeners that can be notified of any changes in the document tree. The following example demonstrates the implementation of [MutationObserver](https://apireference.aspose.com/net/html/aspose.html.dom.mutations/mutationobserver) and how to use it to observe adding new nodes to the document.

{{% alert color="primary" %}} 

If you are observing a node for changes, your callback will not be fired until the DOM has completely finished changing. This behavior was designed to replace DOM Mutation Events and reduce the killing performance issue in the previous specification.

{{% /alert %}} 

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-AdvancedUsage-DOMMutationObserver-ObserveHowNodesAreAdded.cs" >}}
