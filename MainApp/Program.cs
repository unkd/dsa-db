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
        static void Main(string[] args) => Startup();
        
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


                    RecordsCSVReport report = new RecordsCSVReport("all5");
                    report.GenerateFile(records);

                    //CourtGovUaParser parser = new CourtGovUaParser(HtmlStringForParser.GetTestString());
                    ////PrintConsoleRecords.PrintRecords(parser.ParseToRecords());

                    //RecordsCSVReport report = new RecordsCSVReport("all");
                    //report.GenerateFile(parser.ParseToRecords());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
