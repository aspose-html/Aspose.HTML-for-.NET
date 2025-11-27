using Aspose.Html;
using Aspose.Html.Accessibility;
using System.IO;
using Aspose.Html.Accessibility.Results;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Web_Accessibility
{
    public class ColorContrastCheck : TestsBase
    {
        public ColorContrastCheck(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("web-accessibility");
        }


        [Fact(DisplayName = "Check Color Contrast Against Specific Accessibility Criteria")]
        public void CheckColorContrastAgainstAccessibilityCriteriaTest()
        {
            // @START_SNIPPET CheckColorContrastAgainstAccessibilityCriteria.cs
            // Check color contrast on an HTML document using C#
            // Learn more: https://docs.aspose.com/html/net/color-contract-accessibility/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "check-color.html");

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get Principle "1.Perceivable" by code "1" and get guideline "1.4"
            Guideline guideline = webAccessibility.Rules.GetPrinciple("1").GetGuideline("1.4");

            // Get criterion by code, for example 1.4.3
            Criterion criterion = guideline.GetCriterion("1.4.3");

            // Create an accessibility validator, pass the found guideline as parameters and specify the full validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(criterion, ValidationBuilder.All);

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    // Get all result details
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        // If the result of the rule is unsuccessful
                        if (!ruleResult.Success)
                        {
                            // Get errors list
                            foreach (ITechniqueResult result in ruleResult.Errors)
                            {
                                // Check the type of the erroneous element, in this case we have an error in the html element rule
                                if (result.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    // Element of file with error
                                    HTMLElement rule = (HTMLElement)result.Error.Target.Item;

                                    Output.WriteLine("Error in rule {0} : {1}", result.Rule.Code, result.Error.ErrorMessage);
                                    Output.WriteLine("CSS Rule: {0}", rule.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Check Color Contrast")]
        public void CheckColorContrastTest()
        {
            // @START_SNIPPET CheckColorContrast.cs
            // Perform web accessibility validation on HTML document, focusing on the use of colors and color contrast
            // Learn more: https://docs.aspose.com/html/net/color-contract-accessibility/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "check-color.html");

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get Principle "1.Perceivable" by code "1" and get guideline "1.4"
            Guideline guideline = webAccessibility.Rules.GetPrinciple("1").GetGuideline("1.4");

            // Get criterion by code, for example 1.4.3
            Criterion criterion143 = guideline.GetCriterion("1.4.3");

            // Get criterion by code, for example 1.4.6
            Criterion criterion146 = guideline.GetCriterion("1.4.6");

            // Create an accessibility validator, pass the found guideline as parameters and specify the full validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(new IRule[] { criterion143, criterion146 }, ValidationBuilder.All);

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    Output.WriteLine(validationResult.SaveToString());
                }
            }
            // @END_SNIPPET
        }
    }
}
