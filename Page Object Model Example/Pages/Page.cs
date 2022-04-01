using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Object_Model_Example.Pages
{
    // This is the base class for the different pages we create. Therefore, the class has been marked as
    // abstract so that it cannot be implemented.
    public abstract class Page
    {
        // Store the driver and URL of the website so it is available in all classes built upon this one.
        IWebDriver driver;
        string url;

        protected Page(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.url = url;
        }

        public void SetWebPage(string webAddress)
        {
            driver.Url = webAddress;
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetURL()
        {
            return driver.Url;
        }
    }
}
