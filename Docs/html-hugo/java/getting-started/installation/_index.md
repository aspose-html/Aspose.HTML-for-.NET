---
title: Installation
type: docs
weight: 50
url: /java/installation/
---

## **Installing Aspose.HTML for Java from Aspose Repository**
Aspose hosts all Java APIs on [Aspose Repository](https://repository.aspose.com/webapp/#/artifacts/browse/tree/General/repo/com/aspose/). You can easily use Aspose.HTML for Java API directly in your Maven Projects with simple configurations.
### **Specify Aspose Repository Configuration**
First you need to specify Aspose Repository configuration / location in your Maven pom.xml as follows:

{{< highlight java >}}

 <repositories>

     <repository>

         <id>snapshots</id>

         <name>repo</name>

         <url>http://repository.aspose.com/repo/</url>

     </repository>

</repositories>

{{< /highlight >}}
### **Define Aspose.HTML for Java API Dependency**
Then define Aspose.HTML for Java API dependency in your pom.xml as follows:

{{< highlight java >}}

 <dependencies>

    <dependency>

        <groupId>com.aspose</groupId>

        <artifactId>aspose-html</artifactId>

        <version>18.11</version>

    </dependency>

</dependencies>

{{< /highlight >}}

After performing above steps, Aspose.HTML for Java dependency will finally be defined in your Maven Project.
