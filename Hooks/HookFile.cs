using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using SeleniumWebdriver.ComponentHelper;
using TechTalk.SpecFlow;
using AutomationFramework.Resources;



namespace AutomationFramework.Hooks
{
    [Binding]
    public sealed class HookFile : BaseClasses.BaseClass
    {
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public HookFile(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var directory_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            String full_path = directory_path + @"\Reports";

            var htmlReporter = new ExtentHtmlReporter(full_path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario()
        {
            StartNavigation();
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else if (_scenarioContext.TestError != null)
            {
                var mediaEntity = GenericHelper.captureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                {
                    GenericHelper.saveScreenShot();
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                }
                else if (stepType == "When")
                {
                    GenericHelper.saveScreenShot();
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                }
                else if (stepType == "Then")
                {
                    GenericHelper.saveScreenShot();
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                }
                else if (stepType == "And")
                {
                    GenericHelper.saveScreenShot();
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                }
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            CleanUp();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}
