using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MainApp.Interfaces;
using MainApp.Models;

namespace MainApp
{
    public class RecordsCSVReport : IRecordsReport
    {
        private string _fileName;
        public RecordsCSVReport(string fileName)
        {
            _fileName = fileName;
        }
        public void GenerateFile(List<Record> records)
        {
            string path = $"../../Data/{_fileName}.csv";

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine("ЄДРПОУ,Адреса електронної пошти");
                foreach (var record in records)
                {
                    sw.WriteLine($"{record.Edrp},\"{record.Email}\"");
                }
                
            }
        }
    }
}
