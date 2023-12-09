using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using testing_lab5;

namespace testing_lab5_tests
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SearchFilter/";
        }

        [Test]
        public void TestSetPayeeNameNull()
        {
            var mainPage = new MainPage(driver);
            List<string> expect = new List<string>();
            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Bank Savings INCOME Salary 5000");
            expect.Add("Cash EXPENDITURE PowerBill 200");

            mainPage.SetPayeeName("");

            var actual = mainPage.GetSearchResult();
            CollectionAssert.AreEquivalent(expect, actual);
        }
        [Test]
        public void TestSetPayeeNameNegative()
        {
            var mainPage = new MainPage(driver);

            mainPage.SetPayeeName("fghdfg");

            var actual = mainPage.GetSearchResult();
            Assert.That(0, Is.EqualTo(actual.Count));

        }
        [Test]
        public void TestSetPayeeName()
        {
            var mainPage = new MainPage(driver);
            List<string> expect = new() { "Cash EXPENDITURE PowerBill 200" };

            mainPage.SetPayeeName("powerBill");

            var actual = mainPage.GetSearchResult();
            CollectionAssert.AreEquivalent(expect, actual);
        }

        [Test]
        public void TestSetAccountAllAccounts()
        {
            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();
            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Bank Savings INCOME Salary 5000");
            expect.Add("Cash EXPENDITURE PowerBill 200");


            mainPage.SetAccount("All Accounts");


            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);


        }


        [Test]
        public void TestSetAccountCash()
        {
            var mainPage = new MainPage(driver);
            List<string> expect = new List<string>();

            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Cash EXPENDITURE PowerBill 200");


            mainPage.SetAccount("Cash");

            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);

        }

        [Test]
        public void TestSetAccountBankSavings()
        {
            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();

            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Bank Savings INCOME Salary 5000");

            mainPage.SetAccount("Bank Savings");

            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);
        }

        [Test]
        public void TestSetTypeAllTypes()
        {
            var mainPage = new MainPage(driver);
            List<string> expect = new List<string>();

            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Bank Savings INCOME Salary 5000");
            expect.Add("Cash EXPENDITURE PowerBill 200");

            mainPage.SetType("All Types");

            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);

        }

        [Test]
        public void TestSetTypeExpenditure()
        {

            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();

            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Cash EXPENDITURE PowerBill 200");

            mainPage.SetType("EXPENDITURE");
            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);
        }

        [Test]
        public void TestSetTypeIncome()
        {

            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();

            expect.Add("Bank Savings INCOME Salary 5000");


            mainPage.SetType("INCOME");

            var actual = mainPage.GetSearchResult();

            CollectionAssert.AreEquivalent(expect, actual);
        }

        [Test]
        public void TestSetExpenditurePayeesNull()
        {
            var mainPage = new MainPage(driver);
            List<string> expect = new List<string>();
            expect.Add("Cash EXPENDITURE HouseRent 1000");
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Bank Savings INCOME Salary 5000");
            expect.Add("Cash EXPENDITURE PowerBill 200");

            mainPage.SetExpenditurePayees("");

            var actual = mainPage.GetSearchResult();
            CollectionAssert.AreEquivalent(expect, actual);
        }
        [Test]
        public void TestSetExpenditurePayeesNegative()
        {
            var mainPage = new MainPage(driver);

            mainPage.SetExpenditurePayees("fghdfg");

            var actual = mainPage.GetSearchResult();
            Assert.That(0, Is.EqualTo(actual.Count));

        }

        [Test]
        public void TestSetExpenditurePayees()
        {
            var mainPage = new MainPage(driver);

            List<string> expect = new() { "Cash EXPENDITURE PowerBill 200" };


            mainPage.SetExpenditurePayees("powerBill");
            var actual = mainPage.GetSearchResult();


            CollectionAssert.AreEquivalent(expect, actual);


        }


        [Test]
        public void TestSetPayeeNameWithAccount()
        {
            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Cash EXPENDITURE PowerBill 200");



            mainPage.SetExpenditurePayees("bill");
            mainPage.SetAccount("Cash");
            var actual = mainPage.GetSearchResult();


            CollectionAssert.AreEquivalent(expect, actual);

        }

        [Test]
        public void TestSetPayeeNameWithTpe()
        {
            var mainPage = new MainPage(driver);

            List<string> expect = new List<string>();
            expect.Add("Bank Savings EXPENDITURE InternetBill 500");
            expect.Add("Cash EXPENDITURE InternetBill 1200");
            expect.Add("Cash EXPENDITURE PowerBill 200");



            mainPage.SetExpenditurePayees("bill");
            mainPage.SetType("EXPENDITURE");
            var actual = mainPage.GetSearchResult();


            CollectionAssert.AreEquivalent(expect, actual);


        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}