using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Object_Model_Example.Pages
{
    public class HomePage : Page
    {
        //Declaration of the driver and Wait driver.
        private IWebDriver driver { get; set; }
        private WebDriverWait wait;

        // Here we have declared objects to store the elements of the webpage in order to be
        // interacted with by the browser.
        private IWebElement searchBar = null;
        private IWebElement searchButton = null;

        public HomePage(IWebDriver driver, string url) : base(driver, url)
        {
            this.driver = driver;
            SetWebPage(url);

            // Here we have defined the time out period for the wait through the object constructor.
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
        }
        
        public void Search(string input) //Basic method implementation for using the search bar
        {
            // Get the Elements from the webpage (And wait for them to load in)
            wait.Until(driver => driver.FindElement(By.CssSelector("#sbcId > form > input")));
            searchBar = driver.FindElement(By.CssSelector("#sbcId > form > input"));

            // Click on the search bar and pass in the string specified in the class constructor
            searchBar.Click();
            searchBar.SendKeys(input);

            // Here, we are waiting for the search button has been loaded, and then clicking the button
            wait.Until(driver => driver.FindElement(By.CssSelector("#sbcId > form > span:nth-child(7) > button")));
            searchButton = driver.FindElement(By.CssSelector("#sbcId > form > span:nth-child(7) > button"));

            searchButton.Click();
        }
    }
}
