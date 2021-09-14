using System.Collections.Generic;
using MainApp.Models;

namespace MainApp.Interfaces
{
    interface IRecordsReport
    {
        void GenerateFile(List<Record> records);
    }
}
