using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MainApp.Models;

namespace MainApp
{
    public class CourtGovUaParser
    {
        private string html;
        public List<string> CardList = new List<string>();
        public CourtGovUaParser(string htmlTextToParse)
        {
            html = htmlTextToParse;
            ParserUsingAgility();
        }
        public void MyParseHtml()
        {
            string f1Sub = "<div id = \"result\"";
            string fLastSub = "<div id = \"paginate_block_2\"";

            string find_s = html.Substring(html.IndexOf(f1Sub));

            string end = "<hr>\r\n</div>\r\n</div>\r\n</div>";


            string ans = find_s.Remove(find_s.IndexOf(end));

            Console.WriteLine(ans);
        }
        private void ParserUsingAgility()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
            if (node != null)
            {
                foreach (HtmlAgilityPack.HtmlNode n in node.ChildNodes)
                {
                    CardList.Add(n.InnerText);
                    //Console.WriteLine(n.InnerText);
                    //Console.WriteLine("=============================================");
                }
            }
            else
            {
                Console.WriteLine("node is empty!");
            }
        }
        public void PrintCardList()
        {
            foreach (var str in CardList)
            {
                Console.WriteLine(str);
            }
        }

        private void ParseCardList(string cardItem, ref List<string> edrp, ref List<string> email)
        {
            string[] separators = { new string(' ', 3), Environment.NewLine, "\r", "\n" };
            string[] split = cardItem.Split(separators, StringSplitOptions.None);
            for (int i = 1; i < split.Length - 1; i++)
            {
                if (split[i].Trim().ToUpper() == "ЄДРПОУ:" || split[i].Trim() == "< div class=\"left\">ЄДРПОУ:")
                {
                    edrp.Add(split[i+1].Trim());
                }
                if(split[i].Trim() == "Адреса електронної пошти:")
                {
                    email.Add(split[i+1].Trim());
                }
            }

        }

        public List<Record> ParseToRecords()
        {
            List<string> edrpList = new List<string>();
            List<string> emailList = new List<string>();

            foreach (var t in CardList)
            {
                ParseCardList(cardItem: t, ref edrpList, ref emailList);
            }

            List<Record> records = new List<Record>();
            if (edrpList.Count == emailList.Count)
            {
                for (int i = 0; i < edrpList.Count; i++)
                {
                    records.Add(new Record(){Edrp = edrpList[i], Email = emailList[i]});
                }
            }

            return records;

        }

    }
}
