using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MainApp
{
    public static class HtmlStringForParser
    {
        public static string GetTestString()
        {
            return File.ReadAllText("../../htmlForTest.txt");
        }
    }
}
