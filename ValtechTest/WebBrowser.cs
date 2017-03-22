using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ValtechTest
{

    public class WebBrowser
    {
        public static IWebDriver Current
        {
            get
            {

                ChromeDriver driver = new ChromeDriver();
                return driver;
            }
        }

    }
}
