using HomeWork.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HomeWork.Step_Bindings
{
    [Binding]
    public class TheDillingerSearchSteps:IDisposable
    {
        private ChromeDriver driver = new ChromeDriver();
        [Given(@"I have entered google")]
        public void GivenIHaveEnteredGoogle()
        {
            DillingerSearch search = new DillingerSearch(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(search.homepage);
            
        }
        
        [When(@"I type ""(.*)"" in the google search")]
        public void WhenITypeInTheGoogleSearch(string word)
        {
            DillingerSearch search = new DillingerSearch(driver);
            search.EnterWord(word);
            Thread.Sleep(2000);
        }
        
        [When(@"I submit my search word")]
        public void WhenISubmitMySearchWord()
        {
            DillingerSearch search = new DillingerSearch(driver);

            search.SubmitWord();
            Thread.Sleep(2000);
        }
        
        [When(@"I click on the Wikipedia suggestion")]
        public void WhenIClickOnTheWikipediaSuggestion()
        {
            DillingerSearch search = new DillingerSearch(driver);
            search.RedirectToWiki();
        }
        
        [Then(@"I should be able to see theirs wiki page")]
        public void ThenIShouldBeAbleToSeeTheirsWikiPage()
        {
            DillingerSearch search = new DillingerSearch(driver);
            Assert.IsTrue(search.isWiki());
            Thread.Sleep(2000);
        }
        
        [Then(@"I should see that i have a typo")]
        public void ThenIShouldSeeThatIHaveATypo()
        {
            DillingerSearch search = new DillingerSearch(driver);
            Assert.IsTrue(search.isTypo());
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
