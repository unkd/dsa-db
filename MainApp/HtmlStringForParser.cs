using System.IO;

namespace MainApp
{
    public static class HtmlStringForParser
    {
        public static string GetTestString()
        {
            return File.ReadAllText("../../Test/htmlForTest.txt");
        }
    }
}
