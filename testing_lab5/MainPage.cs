using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_lab5
{
    public class MainPage
    {
        private IWebDriver driver;
        private TimeSpan timeout = TimeSpan.FromMilliseconds(2000);

        private By _searchByPayee = By.Id("input1");
        private By _searchByAccount = By.Id("input2");
        private By _searchByType = By.Id("input3");
        private By _searchByExpenditurePayees = By.Id("input4");


        public MainPage(IWebDriver driver) 
        {
            this.driver = driver;

        }

        public MainPage SetPayeeName(string name)
        {
            driver.FindElement(_searchByPayee).Clear();
            driver.FindElement(_searchByPayee).SendKeys(name);
            return this;
        }

        public MainPage SetAccount(string value)
        {

           driver.FindElement(_searchByAccount).SendKeys(value);

            return this;
        }

        public MainPage SetType(string value)
        {
            driver.FindElement(_searchByType).SendKeys(value);
            return this;
        }

        public MainPage SetExpenditurePayees(string name)
        {
            driver.FindElement(_searchByExpenditurePayees).Clear();
            driver.FindElement(_searchByExpenditurePayees).SendKeys(name);
            return this;
        }

        public List<string> GetSearchResult()
        {
            var pelm = driver.FindElement(By.TagName("tbody"));
            var _searchResults = pelm.FindElements(By.ClassName("ng-scope"));

            List<string> results = new List<string>();
            foreach (var item in _searchResults)
            {
                // results.Add(item.Text);
                results.Add(String.Join(" ", item.Text.Split(" ").Skip(1)));
            }

            return results;
        }

    }
}
