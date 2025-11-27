using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using ValidationResult = Aspose.Html.Accessibility.Results.ValidationResult;

namespace Aspose.HTML.Tests.Web_Accessibility
{
    public class ValidationResults : TestsBase
    {
        public ValidationResults(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("web-accessibility");
        }

        
        [Fact(DisplayName = "ValidationResult")]
        public void ValidationResultTest()
        {
            // @START_SNIPPET ValidateHtmlAccessibilityCompliance.cs
            // Validate HTML against WCAG rules using C#
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-validation-results/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create an accessibillity validator with static instance for all rules from repository that match the builder settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Initialize an object of the HTMLDocument class
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                // Checking for success
                if (!validationResult.Success)
                {
                    // Get a list of RuleValidationResult Details
                    foreach (RuleValidationResult detail in validationResult.Details)
                    {
                        Output.WriteLine("{0}:{1} = {2}", detail.Rule.Code, detail.Rule.Description, detail.Success);
                    }
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "RuleValidationResult")]
        public void CriterionResultTest()
        {
            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create an accessibillity validator with static instance for all rules from repository that match the builder settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Initialize an object of the HTMLDocument class
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                // Get a list of RuleValidationResult Details
                foreach (RuleValidationResult result in validationResult.Details)
                {
                    Output.WriteLine("{0}:{1} = {2}", result.Rule.Code, result.Rule.Description, result.Success);                    
                }
            }
        }


        [Fact(DisplayName = "ITechniqueResult")]
        public void IRuleResultTest()
        {
            // @START_SNIPPET CheckWebAccessibilityWithDetailedResults.cs
            // Validate HTML accessibility using C# and print all failed WCAG rule with their descriptions
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-validation-results/

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

                // Take a list of rules results
                foreach (RuleValidationResult ruleResult in validationResult.Details)
                {
                    // List only unsuccessful rule
                    if (!ruleResult.Success)
                    {
                        // Print the code and description of the rule
                        Output.WriteLine("{0}:{1}", ruleResult.Rule.Code, ruleResult.Rule.Description);

                        // Print the results of all methods
                        foreach (ITechniqueResult ruleDetail in ruleResult.Results)
                        {
                            // Print the code and description of the criterions
                            StringBuilder str = new StringBuilder(string.Format("\n{0}: {1} - {2}",
                                ruleDetail.Rule.Code, ruleDetail.Success,
                                ruleDetail.Rule.Description));
                            Output.WriteLine(str.ToString());
                        }
                    }
                }
            }
            // @END_SNIPPET
        }
    }
}
