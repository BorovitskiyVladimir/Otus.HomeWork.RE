using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
namespace Otus.HomeWork.RE
{
    class Program
    {
        static void Main(string[] args)
        {            
            HttpClient client = new HttpClient();
            WebClient webclient = new WebClient();
            MyUrlProcessor urlprocessor = new MyUrlProcessor(client);
            MyFileDownloader filedownloader = new MyFileDownloader(webclient);
            MyHtmlParser parser = new MyHtmlParser();
            string url;
            while (true)
            {
                Console.WriteLine("Введите url-адрес или exit для выхода: ");
                url = Console.ReadLine(); //"https://otus.ru";
                if (url == String.Empty)
                {
                    Console.WriteLine("Для загрузки изображений необходимо ввести url-адрес");
                    continue;
                }
                else if (url == "exit")
                    return;                
                string html = urlprocessor.GetHtmlFromUrl(url.Trim()).ConfigureAwait(false).GetAwaiter().GetResult();
                if (html == String.Empty)
                {
                    Console.WriteLine("Введенный адрес не найден.");
                    Console.ReadLine();
                }
                Dictionary<string, string> images = parser.GetImageListFromHtml(html);
                Console.WriteLine("Найдено изображений: {0}", images.Count);
                filedownloader.DownloadFilesFromWeb(images, url, @"..\..\..\img");
                Console.ReadLine();
            }
        }
                
    }
}
