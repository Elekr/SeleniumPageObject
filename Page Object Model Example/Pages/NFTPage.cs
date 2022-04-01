using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Object_Model_Example.Pages
{
    // Here we have created a class object for the webpage building upon the functionality within the 
    // page class
    public class NFTPage : Page
    {
        private IWebDriver driver;
        
        //Within the Constructor of the class, we reference the base class (Page) to set the values there.
        public NFTPage(IWebDriver driver, string url) : base(driver, url)
        {
            this.driver = driver;
            SetWebPage(url);
        }
    }
}
