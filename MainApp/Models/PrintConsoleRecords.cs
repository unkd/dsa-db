using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public static class PrintConsoleRecords
    {
        public static void PrintRecords(List<Record> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"ЄДРПОУ: {record.Edrp}\tАдреса електронної пошти: {record.Email}");
            }
        }
    }
}