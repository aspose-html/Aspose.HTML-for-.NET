---
title: System Requirements
type: docs
weight: 50
url: /net/system-requirements/
---

## **Required software**
Aspose.HTML for .NET doesn't require any additional software when using .NET Framework to open, analyze, created or convert HTML, XHTML, SVG, MHTML, Markdown and EPUB files.
## **Supported Operating Systems**
### **Windows**
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2008 Server (x64, x86)
- Microsoft Windows 2012 Server (x64, x86)
- Microsoft Windows 2012 R2 Server (x64, x86)
- Microsoft Windows 2016 Server (x64, x86)
- Microsoft Windows 2019 Server (x64, x86)
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Azure

{{% alert color="primary" %}} 

In order to use Aspose.HTML for .NET on Linux or macOS you will need to install .NET Core 2.1 or later.

{{% /alert %}} 

.NET Core 2.1 is supported on the following distributions/versions:
### **macOS**
- Sierra (10.12+) (x64)
### **Linux**
- Red Hat Enterprise Linux 6, 7, 8 (x64)
- CentOS 7+ (x64)
- Oracle Linux 7+ (x64)
- Fedora 30+ (x64)
- Debian 9 (x64, ARM32)
- Ubuntu 16.04, 18.04, 19.04, 19.10 (x64, ARM32)
- Linux Mint 17+ (x64)
- openSUSE 15+ (x64)
- SUSE Enterprise Linux (SLES) 12 SP2+ (x64)
- Alpine Linux 3.8+ (x64)

Based on your Linux distribution or macOS version and the fact that Aspose.HTML for .NET uses the *System.Drawing.Common* assembly, you may need to install additional dependencies. The list of all the supported distributions and additional dependencies can be found [here](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?tabs=netcore21&pivots=os-linux) for Linux and [here](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?tabs=netcore21&pivots=os-macos) for macOS.
## **Supported Frameworks**
Aspose.HTML for .NET supports the following frameworks:
### **.NET Framework**
- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 3.5_ClientProfile
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
### **.NET Standard**
- .NET Standard 2.0
### **.NET Core**
- .NET Core 2.1
## **Development Environments**
You can use Aspose.HTML for .NET to develop applications in any development environment that targets the .NET platform, but the following environments are explicitly supported:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2011
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
## **Trust Level**
Generally, all Aspose .NET components require Full Trust permissions set. The reason is, Aspose .NET components need to access registry settings, system files, other than virtual directory, for certain operations, like reading fonts etc. Moreover, Aspose .NET components (including Aspose.HTML for .NET) are based on core .NET system classes, that also require Full Trust permissions set in many cases.

Internet Service Providers, hosting multiple applications from different companies, mostly enforce a Medium Trust security level. In case of .NET 2.0 such a security level may set the following constraints, which could affect the ability of Aspose.HTML for .NET to perform properly:

- **RegistryPermission** is not available. This means, you can't access the registry.
- **WebPermission** is restricted. This means, your application can only communicate with an address or range of addresses, that you define in the <trust> element.
- **FileIOPermission** is restricted. This means, you can only access files in your applications virtual directory hierarchy.

Due to the reasons, specified above, it is recommended, that Aspose.HTML for .NET is run on servers granting Full Trust permissions.
