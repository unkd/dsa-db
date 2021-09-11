using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainApp.Models;
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
                PrintConsoleRecords.PrintRecords(parser.ParseToRecords());

                /*
                 * Для полной работы закоментировать две строки выше и разкоментироввать строки из work региона
                 *
                 */
                #region work

                //Console.WriteLine("Input Searching word");
                //var search = Console.ReadLine();
                //var html = TestSearchingOnCourtGovUa(search);
                //CourtGovUaParser parser = new CourtGovUaParser(html);
                //var records = parser.ParseToRecords();

                //// Данные получены, дальше делайте что хотите xD
                //// to do...

                #endregion



                #region String experement | удалю потом

                //var list = parser.CardList;
                //string test = list[7];


                //string[] separators = { new string(' ', 3), Environment.NewLine, "\r", "\n" };
                //string[] split = test.Split(separators, StringSplitOptions.None);
                //List<string> edrList = new List<string>();
                //List<string> emailList = new List<string>();
                //List<string> addressList = new List<string>();
                //for (int i = 1; i < split.Length - 1; i++)
                //{
                //    if (split[i].Trim().ToUpper() == "ЄДРПОУ:" || split[i].Trim() == "< div class=\"left\">ЄДРПОУ:")
                //    {
                //        //Console.WriteLine($"ЄДРПОУ: {split[i+1].Trim()}");
                //        edrList.Add(split[i+1].Trim());
                //        //list.Add(new Record() { Name = split[i-1].Trim(), Id = Convert.ToInt32(split[i+1].Trim()) });
                //    }
                //    if(split[i].Trim() == "Адреса електронної пошти:")
                //    {
                //        emailList.Add(split[i+1].Trim());
                //    }
                //    if (split[i].Trim() == "Поштова адреса:")
                //    {
                //        addressList.Add(split[i+1].Trim());
                //    }
                //}

                //if (emailList.Count == edrList.Count)
                //{
                //    for (int i = 0; i < emailList.Count; i++)
                //    {
                //        Console.WriteLine($"ЄДРПОУ: {edrList[i]}\tАдреса електронної пошти: {emailList[i]}");
                //    }
                //}
                //Console.WriteLine(test);
                //Console.WriteLine("\n\n\n");
                //foreach (var str in addressList)
                //{
                //    Console.WriteLine($"Real address: {str}");
                //}


                //Console.WriteLine($"List count {list.Count}");
                //Console.WriteLine();

                //int countEdrp = 0;
                //int countEmail = 0;

                //Console.WriteLine($"String length {test.Length}");
                //for (int i = 0; i < test.Length; i++)
                //{
                //    if (test[i] + "ДРПОУ:\n\r" == ("ЄДРПОУ:\n\r"))
                //    {
                //        //Console.WriteLine(i);
                //        countEdrp++;
                //    }

                //    if (test[i] + "дреса електронної пошти:\n\r" == ("Адреса електронної пошти:\n\r"))
                //    {
                //        countEmail++;
                //    }
                //}

                //Console.WriteLine($"ЄДРПОУ count {countEdrp}");
                //Console.WriteLine($"Email count {countEmail}");

                //for (int i = 7; i < 10; i++)
                //{
                //    Console.WriteLine(list[i].Trim());
                //    Console.WriteLine("====================================");
                //}

                #endregion

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        }
    }
}
