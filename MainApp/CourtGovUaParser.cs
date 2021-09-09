using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MainApp
{
    public class CourtGovUaParser
    {
        private string html;
        public CourtGovUaParser(string htmlTextToParse)
        {
            html = htmlTextToParse;
        }
        public void MyParseHtml()
        {
            string f1Sub = "<div id = \"result\"";
            string fLastSub = "<div id = \"paginate_block_2\"";

            string find_s = html.Substring(html.IndexOf(f1Sub));

            string end = "<hr>\r\n</div>\r\n</div>\r\n</div>";


            string ans = find_s.Remove(find_s.IndexOf(end));

            //for (int i = 0; i < find_s.Length; i++)
            //{
            //    //ans = find_s.
            //}

            Console.WriteLine(ans);
        }

        public void ParserUsingAgility()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
            if (node != null)
            {
                foreach (HtmlAgilityPack.HtmlNode n in node.ChildNodes)
                {
                    Console.WriteLine(n.InnerText);
                    Console.WriteLine("=============================================");
                }
            }
            else
            {
                Console.WriteLine("node is empty!");
            }
        } 
    }
}
