using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using System.IO;
using Aspose.Html.Accessibility.Results;
using Xunit;
using Xunit.Abstractions;


namespace Aspose.HTML.Tests.Web_Accessibility
{
    public class WebAccessibilityRules : TestsBase
    {
        public WebAccessibilityRules(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("web-accessibility");
        }        


        [Fact(DisplayName = "Check HTML Against Specific Web Accessibility Rules")]
        public void CheckHTMLAgainstSpecificWebAccessibilityRulesTest()
        {
            // @START_SNIPPET CheckHtmlAgainstSpecificWebAccessibilityRules.cs
            // Validate an HTML document using specific rule codes with C#
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-rules/

            string htmlPath = Path.Combine(DataDir, "input.html");

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // List of necessary rules for checking (rule code according to the specification) 
            string[] rulesCode = new string[] { "H2", "H37", "H67", "H86" };

            // Get the required IList<Rule> rules from the rules reference
            IList<IRule> rules = webAccessibility.Rules.GetRules(rulesCode);

            // Create an accessibility validator, pass the found rules as parameters, and specify the full validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(rules, ValidationBuilder.All);

            // Initialize an object of the HTMLDocument
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Check the document
                ValidationResult validationResult = validator.Validate(document);

                // Return the result in string format
                // SaveToString - return only errors and warnings
                Output.WriteLine(validationResult.SaveToString());
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "GetRules")]
        public void GetRulesTest()
        {
            // @START_SNIPPET GetAccessibilityRulesByCode.cs
            // Retrieve and list accessibility rules by code with their descriptions from the rules repository
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-rules/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // List of rule codes can contain both technique codes and principles, guidelines and criteria - all rules that implement the interface IRule
            string[] rulesCodes = new string[] { "H2", "H37", "H30", "1.1", "1.2.1" };

            // Get a list of IRule objects; if a rule with the specified code is not found, it will not be in the list
            IList<IRule> rules = webAccessibility.Rules.GetRules(rulesCodes);

            // Get code and description of rule
            foreach (IRule rule in rules)
                Output.WriteLine("{0}:{1}", rule.Code, rule.Description);
            // @END_SNIPPET
        }


        [Fact(DisplayName = "GetPrinciple")]
        public void GetPrincipleTest()
        {
            // @START_SNIPPET GetAccessibilityPrincipleByCode.cs
            // Retrieve and display the code and description of an accessibility principle by its code
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-rules/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get the principle by code
            Principle rule = webAccessibility.Rules.GetPrinciple("1");

            // Get code and description of principle
            Output.WriteLine("{0}:{1}", rule.Code, rule.Description);  // output: 1:Perceivable
            // @END_SNIPPET
        }


        [Fact(DisplayName = "GetGuideline")]
        public void GetGuidelineTest()
        {
            // @START_SNIPPET GetAccessibilityGuideline.cs
            // Retrieve and display the code and description of an accessibility guideline
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-rules/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get the principle by code 
            Principle principle = webAccessibility.Rules.GetPrinciple("1");

            // Get guideline 1.1
            Guideline guideline = principle.GetGuideline("1.1");
            if (guideline != null)
            {
                Output.WriteLine("{0}:{1}", guideline.Code, guideline.Description, guideline);  // output: 1.1:Text Alternatives
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "GetCriterion")]
        public void GetCriterionTest()
        {
            // @START_SNIPPET GetAccessibilityCriterion.cs
            // Retrieve and display the code and description of an accessibility criterion
            // Learn more: https://docs.aspose.com/html/net/web-accessibility-rules/

            // Initialize a webAccessibility container
            WebAccessibility webAccessibility = new WebAccessibility();

            // Get the principle by code 
            Principle principle = webAccessibility.Rules.GetPrinciple("1");

            // Get guideline 
            Guideline guideline = principle.GetGuideline("1.1");

            // Get criterion by code
            Criterion criterion = guideline.GetCriterion("1.1.1");
            if (criterion != null)
            {
                Output.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level); // output: 1.1.1:Non-text Content - A

                // Get all Sufficient Techniques and write to console
                foreach (IRule technique in criterion.SufficientTechniques)
                    Output.WriteLine("{0}:{1}", technique.Code, technique.Description);
            }
            // @END_SNIPPET
        }
    }
}
