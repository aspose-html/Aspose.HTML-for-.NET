---
title: How to Run the Examples
type: docs
weight: 60
url: /net/how-to-run-the-examples/
---

## **Software Requirements**
Please make sure you meet the following requirements before downloading and running the examples:

1. Visual Studio 2010 or higher.
1. Make sure that **NuGet Package Manager** is installed in Visual Studio. For details on how to install **NuGet Package Manager** please check <http://docs.nuget.org/ndocs/guides/install-nuget>.
1. Go to **Tools**->**Options**->**NuGet Package Manager**->**Package Sources** and make sure that the option **nuget.org** is checked.
1. Example project uses NuGet Automatic Package Restore feature therefore you should have an active internet connection. If you do not have an active internet connection on the machine where examples are to be executed please check [Installation](/html/net/installation/) and manually add the reference to Aspose.HTML.dll in the example project.
## **Download from GitHub**
All examples of Aspose.HTML for .NET are hosted on [GitHub](https://github.com/aspose-html/Aspose.HTML-for-.NET).

- You can either clone the repository using your favorite GitHub client or download the ZIP file from [here](https://github.com/aspose-html/Aspose.HTML-for-.NET/archive/master.zip).
- Extract the contents of ZIP file to any folder on your computer. All the examples are located in the **Examples** folder.
- The project is created in Visual Studio 2013, but the solution files are compatible with Visual Studio 2010 SP1 and higher.
- Open the solution file in Visual Studio and build the project.
- On first run the dependencies will automatically be downloaded via NuGet.
- **Data** folder at the root folder of **Examples** contains input files which CSharp examples use. It is mandatory that you download the **Data** folder along with the examples project.
- Open RunExamples.cs file, all the examples are called from here.
- Uncomment the examples you want to run from within the project.

Please feel free to reach out using our [Forums](https://forum.aspose.com/c/html) if you have any issues setting up or running the examples.
## **Contribute**
If you like to add or improve an example, we encourage you to contribute to the project. All examples and showcase projects in this repository are open source and can be freely used in your own applications.

To contribute, you can fork the repository, edit the source code and create a pull request. We will review the changes and include it in the repository if found helpful.
