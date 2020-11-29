using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AngleSharp.Html.Parser;
using AngleSharp;
using AngleSharp.Dom;



namespace Caesar
{
    public class Parser
    {
        public string ParseHtml(string source)
        {
            var doc = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(source);
            var TextList = doc.Result.DocumentElement.QuerySelectorAll("h1, h2, h3, .p").Where(item => item.ParentElement.ClassName == "t hya");
            String text = "";
            foreach (var item in TextList)
            {
                text += item.TextContent + "\n";
            }
            return text;
        }

        public String ParseFullBook(string path, int start, int finish)
        {
            string[] address = path.Split("<HERE>");
            String resultText = "";
            Console.WriteLine("Parse Full Book");
            for (int i = start; i <= finish; i++)
            {
                Console.Clear();
                resultText += ParseHtml(address[0] + i + address[1]);
                Console.WriteLine(i + " / " + finish);
            }
            return resultText;
        }

    }
}
