using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace MainApp
{
    class Program
    {
        static void TestSelenium()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");

            IWebElement ele = driver.FindElement(By.Name("q"));
            ele.SendKeys("captain marvel");

            IWebElement ele1 = driver.FindElement(By.Name("btnK"));
            ele1.Click();

            Thread.Sleep(3000);

            driver.Close();
            Console.Write("test case ended ");
        }

        static string TestSearchingOnCourtGovUa(string search)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://email.court.gov.ua/");
            
            IWebElement ele = driver.FindElement(By.Name("term"));
            ele.SendKeys(search);

            IWebElement ele1 = driver.FindElement(By.Name("commit"));
            ele1.Click();
            Thread.Sleep(3000);
            string ans = driver.PageSource;
            Thread.Sleep(3000);
            driver.Close();
            Console.Write("test case ended ");

            return ans;
        }

        static void Main(string[] args)
        {
            try
            {
                //TestSelenium();
                //var html = TestSearchingOnCourtGovUa("Одес");
                //Console.WriteLine(html);

                //Console.WriteLine(HtmlStringForParser.GetTestString());
                CourtGovUaParser parser = new CourtGovUaParser(HtmlStringForParser.GetTestString());
                //parser.MyParseHtml();
                parser.ParserUsingAgility();
                
                //Console.WriteLine(parser.GetBoxPageCount());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        }
    }
}
