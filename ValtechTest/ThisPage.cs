using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ValtechTest
{
    public class ThisPage
    {

        public readonly IWebDriver WebDriver;
        public ThisPage(IWebDriver driver)
        {
            this.WebDriver = driver;

            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(), 'Latest news')]")]
        public IWebElement Test1 { get; set; }

       
    }
}

