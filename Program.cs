using Microsoft.Toolkit.Parsers.Rss;
using System;
using System.Net.Http;

namespace RSSParser
{
    class Program
    {
        static void Main(string[] args)
        {

            ParseRSS();
            Console.ReadKey();
        }

        public static async void ParseRSS()
        {
            string feed = null;

            using (var client = new HttpClient())
            {
                try
                {
                    feed = await client.GetStringAsync("https://news.yandex.ru/internet.rss");
                }
                catch { }
            }

            if (feed != null)
            {
                var parser = new RssParser();
                var rss = parser.Parse(feed);

                foreach (var element in rss)
                {
                    Console.WriteLine($"Заголовок: {element.Title}");
                    Console.WriteLine($"Текст: {element.Summary}");
                    Console.WriteLine($"Ссылка: {element.FeedUrl}");
                }
            }
        }
    }
}
