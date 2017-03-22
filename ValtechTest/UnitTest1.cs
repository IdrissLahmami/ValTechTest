using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

/**************************/
/* Author: Idriss Lahmami */
/* Date: 22/03/2017       */
/**************************/

namespace ValtechTest
{
    //Unit Tests to prove functionality
    [TestFixture]
    public class MainTests
    {
        public static IWebDriver Driver { get; set; }
        //public object TestDiv { get; private set; }
      
        //protected internal IWebElement TestDiv { get; set; }

        private static IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

        //TO DO:
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(), 'Latest news')]")]
        public IWebElement Test1 { get; set; }


        [TestFixtureSetUp]
        public void Setup()
        {
            //TO Do: Tidy up later
            //Driver = new ChromeDriver(@"C:\ChromeDriver");
            //Driver = new FirefoxDriver();
            Driver = new ChromeDriver();

        }


        [Test]
        public void ANavigateToHomePage()
        {


            Driver.Navigate().GoToUrl("https://www.valtech.com/");

            //b. Assert that the “Latest News” section is displaying
            IWebElement tagLabel = Driver.FindElement(By.TagName("h2"));

            var elementTxt = Driver.FindElement(By.XPath("//h2[contains(text(),'Latest news')]"));
            NUnit.Framework.Assert.That(elementTxt.Text, Is.EqualTo("LATEST NEWS"));

            Console.Write("Display Text: "); Console.WriteLine(elementTxt.Text);
           
           

        }

        


        [Test]
        public void BNavigateToCases()
        {
            //Navigate to CASES, SERVICES and JOBS pages via top navigation and assert that H1 tag in each page is displaying the relevant page name. 
            //Ex H1 tag in Services page is displaying as “Services”
            Driver.Navigate().GoToUrl("https://www.valtech.com/cases");

            //b. Assert that the “Work” section is displaying
            IWebElement tagLabel = Driver.FindElement(By.TagName("h1"));

            var elementTxt = Driver.FindElement(By.XPath("//h1[contains(text(),'Work')]"));
            NUnit.Framework.Assert.That(elementTxt.Text, Is.EqualTo("Work"));

            Console.Write("Display Text: "); Console.WriteLine(elementTxt.Text);
            //Console.Write("Tag: "); Console.WriteLine(tagLabel.GetAttribute("h1"));
        }

        [Test]
        public void CNavigateToServices()
        {
            //Navigate to CASES, SERVICES and JOBS pages via top navigation and assert that H1 tag in each page is displaying the relevant page name. 
            //Ex H1 tag in Services page is displaying as “Services”
            Driver.Navigate().GoToUrl("https://www.valtech.com/services");

            //b. Assert that the “Work” section is displaying
            IWebElement tagLabel = Driver.FindElement(By.TagName("h1"));

            var elementTxt = Driver.FindElement(By.XPath("//h1[contains(text(),'Services')]"));
            NUnit.Framework.Assert.That(elementTxt.Text, Is.EqualTo("Services"));

            Console.Write("Display Text: "); Console.WriteLine(elementTxt.Text);
            //Console.Write("Tag: "); Console.WriteLine(tagLabel.GetAttribute("h1"));
        }

        [Test]
        public void DNavigateToJobs()
        {
            //Navigate to CASES, SERVICES and JOBS pages via top navigation and assert that H1 tag in each page is displaying the relevant page name. 
            //Ex H1 tag in Services page is displaying as “Services”
            Driver.Navigate().GoToUrl("https://www.valtech.com/jobs");

            //b. Assert that the “Work” section is displaying
            IWebElement tagLabel = Driver.FindElement(By.TagName("h1"));

            var elementTxt = Driver.FindElement(By.XPath("//h1[contains(text(),'Careers')]"));
            NUnit.Framework.Assert.That(elementTxt.Text, Is.EqualTo("Careers"));

            Console.Write("Display Text: "); Console.WriteLine(elementTxt.Text);
            // Console.Write("Tag: "); Console.WriteLine(tagLabel.GetAttribute("h1"));
        }

        [Test]
        public void ENavigateToContactsPage()
        {
            //3. Navigate to Contact page and output how many Valtech offices in total

            //This is the Page Factory implementation using the FindsBy above
            PageFactory.InitElements(Driver, this);
            Driver.Navigate().GoToUrl("https://www.valtech.com/");

            //Wait for page to load
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));


            //Find all elements using Css selector on home page
            IList<IWebElement> elements = Driver.FindElements(By.CssSelector(".push-state.js"));

            //Store found cities in list
            List<string> city = new List<string>();

            //Delimeter on pipe
            char[] delChars = {'|'};

            //Extract text from home page
            foreach (var e in elements)
            {

                string text = Convert.ToString(e.Text);

                //Debug text  
                Console.WriteLine(text);

                //Get the Start of word positions using IndexOf         
                int fStart = text.IndexOf("Aarhus");

                //Debug start of city position
                Console.WriteLine(text.IndexOf("Aarhus"));
                Console.WriteLine("Aarhus".Length);
                Console.WriteLine(fStart);

                //Debug end of city position
                int fEnd = text.IndexOf("Västerås") + "Västerås".Length;
                Console.WriteLine(fEnd);

                //Copy subset of string containing only cities
                string CitiesStr = text.Substring(fStart, fEnd - fStart);

                //Debug all cities found
                Console.WriteLine(CitiesStr);

                //split cities on pipe delimeter
                string[] citiesSplit = CitiesStr.Split(delChars);

                //Extract cities and add to list
                foreach (var s in citiesSplit)
                {
                    //Debug
                    Console.WriteLine(s);
                    //Extract and copy cities to list
                    city.Add(s);
                }


                Console.Write("Valtech offices in total: ");
                Console.WriteLine(city.Count);
                NUnit.Framework.Assert.That(city.Count, Is.EqualTo(29));

            }
        }



        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }



}