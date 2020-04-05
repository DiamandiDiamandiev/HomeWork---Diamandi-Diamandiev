using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.PageObjects
{
    class DillingerSearch
    {
        public readonly string homepage = "https://www.google.bg/?hl=bg";

        private IWebDriver driver;


        readonly By googleSearchField = By.CssSelector(".a4bIc > input[role='combobox']");
        readonly By googleSearchButton = By.Name("btnK");
        readonly By wikipediaredirect = By.CssSelector("div:nth-of-type(1) > .rc .DKV0Md.LC20lb");
        readonly By wikipage = By.CssSelector("div#mw-content-text > .mw-parser-output");
        readonly By typo = By.CssSelector("#fprs .gL9Hy:nth-child(1)");

        public DillingerSearch(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void EnterWord(string word)
        {
            driver.FindElement(googleSearchField).Clear();
            driver.FindElement(googleSearchField).SendKeys(word);
        }
        public void SubmitWord()
        {
            driver.FindElement(googleSearchButton).Submit();
          }

        public void RedirectToWiki()
        {
            driver.FindElement(wikipediaredirect).Click();
        }

        public bool isWiki()
        {
            return driver.FindElement(wikipage).Displayed;
        }
        public bool isTypo()
        {
            return driver.FindElement(typo).Displayed;
        }
    }
}
