using Aspose.Html;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests
{
    public abstract class TestsBase
    {
        // Fields
        private readonly ITestOutputHelper output;
        private readonly string dataDir = "./../../../../tests-data/";
        private readonly string outDir = "./../../../../tests-out/";
        private readonly string outUrl = "./../../../tests-out/";
        private readonly string svgNS = "http://www.w3.org/2000/svg";

        private string exampleDir;

        // Properties

        protected ITestOutputHelper Output
        {
            get { return this.output; }
        }

        public string LicenseDir
        {
            get { return Path.Combine(dataDir, "license"); }
        }

        public string DataDir
        {
            get { return Path.Combine(dataDir); }
        }

        public string OutputDir
        {
            get { return Path.Combine(outDir, exampleDir); }
        }

        public string OutputUrl
        {
            get { return Path.Combine(outUrl, exampleDir); }
        }

        public string SvgNamespace
        {
            get { return svgNS; }
        }

        // Constructor

        public TestsBase(ITestOutputHelper output)
        {
            this.output = output;
            SetOutputDir();

            // Set license (if used)
            string licensePath = Path.Combine(LicenseDir, "Aspose.HTML.NET.lic");
            if (File.Exists(licensePath))
            {
                License license = new License();
                license.SetLicense(licensePath);
            }
        }

        protected void SetOutputDir(string dir = "")
        {
            exampleDir = dir;

            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            if (!Directory.Exists(OutputDir))
            {
                Directory.CreateDirectory(OutputDir);
            }
        }
    }

}