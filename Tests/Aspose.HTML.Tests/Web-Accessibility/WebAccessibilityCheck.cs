using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;
using Aspose.Html.Dom.Css;
using System;
using System.IO;
using System.Text;
using System.Xml;
using Xunit;
using Xunit.Abstractions;
using ValidationResult = Aspose.Html.Accessibility.Results.ValidationResult;

namespace Aspose.HTML.Tests.Web_Accessibility
{
    public class WebAccessibilityCheck : TestsBase
    {
        public WebAccessibilityCheck(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("web-accessibility");
        }


        [Fact(DisplayName = "Web Accessibility Check")]
        public void WebAccessibilityCheckTest()
        {
            // @START_SNIPPET WebAccessibilityCheck.cs
            // Check HTML document for WCAG compliance in C# and log each rule code, description, and pass status
            // Learn more: https://docs.aspose.com/html/net/web-accessibility/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create an accessibility validator
            AccessibilityValidator validator = webAccessibility.CreateValidator();

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "test-checker.html");

            // Initialize an HTMLDocument object
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Check the document
                ValidationResult result = validator.Validate(document);

                // Checking for success
                if (!result.Success)
                {
                    foreach (RuleValidationResult detail in result.Details)
                    {
                        // ... do the analysis here...
                        Output.WriteLine("{0}:{1} = {2}", detail.Rule.Code, detail.Rule.Description, detail.Success);
                    }
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Validate website")]
        public void ValidateWebsiteTest()
        {
            // @START_SNIPPET ValidateWebsiteAccessibility.cs
            // Check website for WCAG compliance in C#
            // Learn more: https://docs.aspose.com/html/net/web-accessibility/

            // Initialize webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create an accessibillity validator with static instance for all rules from repository that match the builder settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Initialize an HTMLDocument object
            using (HTMLDocument document = new HTMLDocument("https://products.aspose.com/html/net/generators/video/"))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                // Checking for success
                if (!validationResult.Success)
                {
                    // Get a list of Details
                    foreach (RuleValidationResult detail in validationResult.Details)
                    {
                        Output.WriteLine("{0}:{1} = {2}", detail.Rule.Code, detail.Rule.Description, detail.Success);
                    }
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Check Alternative Text")]
        public void CheckAltTextTest()
        {
            // @START_SNIPPET CheckHtmlImageAltTextAccessibility.cs
            // Validate HTML image alt text accessibility with detailed error reporting using C#
            // Learn more: https://docs.aspose.com/html/net/screen-reader-accessibility/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "alt-tag.html");

            // Initialize webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get from the rules list Principle "1. Perceivable" by code "1" and get guideline "1.1 Text Alternatives"
            Guideline guideline = webAccessibility.Rules.GetPrinciple("1").GetGuideline("1.1");

            // Create an accessibility validator - pass the found guideline as parameters and specify the full validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, ValidationBuilder.All);

            // Initialize an HTMLDocument object
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    // Get all the result details 
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        // If the result of the rule is unsuccessful
                        if (!ruleResult.Success)
                        {
                            // Get an errors list 
                            foreach (ITechniqueResult result in ruleResult.Errors)
                            {
                                // Check the type of the erroneous element, in this case, we have an error in the HTML Element
                                if (result.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement rule = (HTMLElement)result.Error.Target.Item;
                                    Output.WriteLine("Error in rule {0} : {1}", result.Rule.Code, result.Error.ErrorMessage);
                                    Output.WriteLine("HTML Element: {0}", rule.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }
            // @END_SNIPPET
        }
        

        [Fact(DisplayName = "Validate Multimedia")]
        public void ValidateMultimediaTest()
        {
            // @START_SNIPPET ValidateMultimediaAccessibility.cs
            // Validate HTML for multimedia accessibility using C#
            // Learn more: https://docs.aspose.com/html/net/multimedia-accessibility/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get from the rules list Principle "1.Perceivable" by code "1" and get guideline "1.2 Time-based Media"
            Guideline guideline = webAccessibility.Rules.GetPrinciple("1").GetGuideline("1.2");

            //Create an accessibility validator, pass the found guideline as parameters, and specify the full validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, ValidationBuilder.All);

            // Initialize an HTMLDocument object
            using (HTMLDocument document = new HTMLDocument("https://www.youtube.com/watch?v=Yugq1KyZCI0&t=4s"))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                // Checking for success
                if (!validationResult.Success)
                {
                    // Get all result details
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        // If the result of the rule is unsuccessful
                        if (!ruleResult.Success)
                        {

                            // Get an errors list
                            foreach (ITechniqueResult result in ruleResult.Errors)
                            {
                                // Check the type of the erroneous element
                                if (result.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement rule = (HTMLElement)result.Error.Target.Item;
                                    Output.WriteLine("Error in rule {0} : {1}", result.Rule.Code, result.Error.ErrorMessage);
                                    Output.WriteLine("HTML Element: {0}", rule.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }
            // @END_SNIPPET
        }
        

        [Fact(DisplayName = "Errors")]
        public void ErrorsTest()
        {
            // @START_SNIPPET CheckWebAccessibilityWithCompleteErrorDetails.cs
            // Check HTML for WCAG compliance and output failed rule codes and error messages
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-errors-and-warnings/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create an accessibillity validator with static instance for all rules from repository that match the builder settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            string documentPath = Path.Combine(DataDir, "input.html");

            // Initialize an object of the HTMLDocument class
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                foreach (RuleValidationResult ruleResult in validationResult.Details)
                {
                    //  list only unsuccessful rule
                    if (!ruleResult.Success)
                    {
                        // print the code and description of the rule
                        Output.WriteLine("{0}:{1} = {2}", ruleResult.Rule.Code, ruleResult.Rule.Description, ruleResult.Success);
                        // print the results of methods with errors
                        foreach (ITechniqueResult ruleDetail in ruleResult.Errors)
                        {
                            // print the code and description of the method
                            StringBuilder str = new StringBuilder(string.Format("\n{0}: {1} - {2}",
                                                                       ruleDetail.Rule.Code, ruleDetail.Success,
                                                                       ruleDetail.Rule.Description));
                            // get an error object 
                            IError error = ruleDetail.Error;
                            // get a target object 
                            Target target = error.Target;
                            // get error type and message 
                            str.AppendFormat("\n\n\t{0} : {1}", error.ErrorTypeName, error.ErrorMessage);
                            if (target != null)
                            {
                                // Checking the type of the contained object for casting and working with it
                                if (target.TargetType == TargetTypes.CSSStyleRule)
                                {
                                    ICSSStyleRule cssRule = (ICSSStyleRule)target.Item;
                                    str.AppendFormat("\n\n\t{0}", cssRule.CSSText);
                                }
                                if (ruleDetail.Error.Target.TargetType == TargetTypes.CSSStyleSheet)
                                    str.AppendFormat("\n\n\t{0}", ((ICSSStyleSheet)target.Item).Title);

                                if (ruleDetail.Error.Target.TargetType == TargetTypes.HTMLElement)
                                    str.AppendFormat("\n\n\t{0}", ((HTMLElement)target.Item).OuterHTML);
                            }
                            Output.WriteLine(str.ToString());
                        }
                    }
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "SaveToString")]
        public void SaveToStringTest()
        {
            // @START_SNIPPET CheckWebAccessibilityAndSaveResultsToString.cs
            // Validate HTML for accessibility and export all errors and warnings as a string
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-validation-results-save/

            string htmlPath = Path.Combine(DataDir, "input.html");

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                ValidationResult validationresult = validator.Validate(document);

                // get rules errors in string format 
                string content = validationresult.SaveToString();

                // SaveToString - return only errors and warnings
                // if everything is ok, it will return "validationResult:true"
                Output.WriteLine(content);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Save To JSON Format")]
        public void SaveToJsonTest()
        { 
            string htmlPath = Path.Combine(DataDir, "input.html");
            string outputFile = Path.Combine(OutputDir, "output.json");

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationresult = validator.Validate(document);

                // create a StringWriter object
                using (StringWriter sw = new StringWriter())
                {
                    if (!validationresult.Success)
                    {
                        // specify the format ValidationResultSaveFormat JSON or XML
                        validationresult.SaveTo(sw, ValidationResultSaveFormat.JSON);
                        // after that you can save the string to a file
                        File.WriteAllText(outputFile, sw.ToString());
                    }
                    Output.WriteLine(sw.ToString());
                }
            }
        }


        [Fact(DisplayName = "Save To XML Format")]
        public void SaveToXmlTest()
        {
            // @START_SNIPPET CheckWebAccessibilityAndSaveResultsToXml.cs
            // Validate HTML for accessibility and export all errors and warnings as an XML
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-validation-results-save/

            string htmlPath = Path.Combine(DataDir, "input.html");

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationresult = validator.Validate(document);
                
                using (StringWriter sw = new StringWriter())
                {
                    validationresult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    string xml = sw.ToString();

                    Output.WriteLine(xml);

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xml);
                    }
                    catch (Exception)
                    {
                        Output.WriteLine("Wrong xml format");
                    }
                }
            }
            // @END_SNIPPET
        }
    }
}
