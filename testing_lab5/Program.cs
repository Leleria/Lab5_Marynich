
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using testing_lab5;

IWebDriver driver = new ChromeDriver();
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);


driver.Url = "https://www.globalsqa.com/angularJs-protractor/SearchFilter/";
var mainPage = new MainPage(driver);
Thread.Sleep(1000);


mainPage.SetPayeeName("power");

Thread.Sleep(1000);
mainPage.SetPayeeName("Bill");

//var res = mainPage.GetSearchResult();
// проанализировать.





//mainPage.SetAccount("Cash");



//mainPage.SetType("EXPENDITURE");

//mainPage.SetExpenditurePayees("powerBill");


mainPage.GetSearchResult();
//Console.WriteLine("Количество записей после поиска: " + mainPage.GetSearchResult().Count());
driver.Quit();

