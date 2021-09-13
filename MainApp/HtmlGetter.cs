using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MainApp
{
    /// <summary>
    /// class for getting html code from web page using OpenQA.Selenium and Firefox browser 
    /// </summary>
    public class HtmlGetter
    {
        private static string _url = "http://email.court.gov.ua/";

        /// <summary>
        /// Method for testing Selenium using Firefox and www.google.com as testing url
        /// </summary>
        public static void TestSelenium()
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


        /// <summary>
        /// Method getting html from http://email.court.gov.ua/" where string search is input string
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string GetHtml(string search)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(_url);
            
            IWebElement ele = driver.FindElement(By.Name("term"));
            ele.SendKeys(search);

            IWebElement ele1 = driver.FindElement(By.Name("commit"));
            ele1.Click();

            // Sleeps need to catch AJAX 
            Thread.Sleep(3000);
            string ans = driver.PageSource;
            Thread.Sleep(3000);
            driver.Close();
            Console.WriteLine("Case ended ");

            return ans;
        }
    }
}
