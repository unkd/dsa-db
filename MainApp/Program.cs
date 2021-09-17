using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MainApp.Models;

namespace MainApp
{
    class Program
    {
        static void Startup()
        {
            string logRecordsPath = "../../Logs/all-records.log";
            if(File.Exists(logRecordsPath))
                File.Delete(logRecordsPath); // delete log file after last session 
            
            var regions = new List<string>()
            {
                "Кие", "Дне", "Дон", "Зап", "Пол", "Хар", "Оде", "Луг", "Сев", "Ник", "Чер", "Льв", "Рес", "Сум", "Кир",
                "Ива", "Фра", "Вол", "Ров", "Вин", "Хер", "Хме", "Жит", "Зак", "Тер", "Киї", "Він", "Дні", "Кір", "Іва", "Рів", "Мик"
            };

            using (StreamWriter logWriter = new StreamWriter("../../Logs/app.log", false))
            {
                Console.SetOut(logWriter);
                try
                {
                    List<Record> records = new List<Record>();
                    foreach (var region in regions)
                    {
                        CourtGovUaParser parser = new CourtGovUaParser(HtmlGetter.GetHtml(region));
                        var part = parser.ParseToRecords();
                        records.AddRange(part);
                        using (StreamWriter sw = new StreamWriter(logRecordsPath, true, Encoding.UTF8))
                        {
                            sw.WriteLine($"From '{region}' getting {part.Count} records");
                        }
                    }

                    records = records.Distinct(new RecordComparer()).ToList();


                    RecordsCSVReport report = new RecordsCSVReport("all4");
                    report.GenerateFile(records);

                    //CourtGovUaParser parser = new CourtGovUaParser(HtmlStringForParser.GetTestString());
                    ////PrintConsoleRecords.PrintRecords(parser.ParseToRecords());

                    //RecordsCSVReport report = new RecordsCSVReport("all");
                    //report.GenerateFile(parser.ParseToRecords());

                    /*
                     * Для полной работы закоментировать две строки выше и разкоментироввать строки из work региона
                     *
                     */

                    #region work

                    //Console.WriteLine("Input Searching word");
                    //var search = Console.ReadLine();
                    //var html = HtmlGetter.GetHtml(search);
                    //CourtGovUaParser parser = new CourtGovUaParser(html);
                    //var records = parser.ParseToRecords();
                    //PrintConsoleRecords.PrintRecords(parser.ParseToRecords());
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

        static void Main(string[] args) => Startup();
    }
}
