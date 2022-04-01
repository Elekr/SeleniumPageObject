using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Page_Object_Model_Example.Pages;

namespace Page_Object_Model_Example
{
    public class Tests
    {
        // Declaration of the web drivers used to access the browser
        IWebDriver edgeDriver;
        IWebDriver chromeDriver;

        // Here, the URL and Title of the webpages used have been defined into one variable (tuple)
        (string websiteURL, string websiteTitle) homePage = ("https://ibase1.sharepoint.com/sites/hub", "QT ONE - Home");
        (string websiteURL, string websiteTitle) NFTPage = ("https://ibase1.sharepoint.com/sites/NFTSandbox", "QT UK NFT Forum - Home");

        // The set up annotation specifies that this method is ran before each test.
        [SetUp]
        public void Setup()
        {
            //Set up the Driver to communicate with the browser
            edgeDriver = new EdgeDriver("C:/Users/thomas.crosby/Documents/Projects/Browser Drivers");
            chromeDriver = new ChromeDriver("C:/Users/thomas.crosby/Documents/Projects/Browser Drivers");

        }

        // The test annotation notifies the compiler that this is a test and also for reporting.
        [Test]
        public void EdgeHomePageTest()
        {
            //Pass the driver over to the HomePage class
            HomePage qt1 = new HomePage(edgeDriver, homePage.websiteURL);
            //Check that the webpage has the correct title
            string title = qt1.GetTitle();
            Assert.AreEqual(homePage.websiteTitle, title);
        }

        [Test]
        public void SearchTest()
        {
            HomePage qt1 = new HomePage(edgeDriver, homePage.websiteURL);
            //Query the search box at the top of the page with the word "hello"
            qt1.Search("hello");
            
            //Check that the website URL is correct
            Assert.AreEqual("https://ibase1.sharepoint.com/sites/hub", qt1.GetURL());
        }

        [Test]
        public void EdgeNFTTest()
        {
            //Pass the EDGE driver over to the HomePage class
            NFTPage nft = new NFTPage(edgeDriver, NFTPage.websiteURL);

            //Check that the webpage is correct
            string title = nft.GetTitle();
            Assert.AreEqual(NFTPage.websiteTitle, title);
        }

        [Test]
        public void ChromeHomePageTest()
        {
            HomePage nft = new HomePage(chromeDriver, homePage.websiteURL);

            //Check that the webpage is correct
            string title = nft.GetTitle();
            Assert.AreEqual(homePage.websiteTitle, title);
        }

        //The Tear Down method is ran after a test has been completed.
        [TearDown]
        public void TearDown()
        {
            //Closes all windows that are currently open
            edgeDriver.Quit();
            chromeDriver.Quit();
            //Removes the connection and releases unmanaged resources
            edgeDriver.Dispose();
            chromeDriver.Dispose();
        }
    }
}