using System;
using System.Collections.Generic;
using System.Net;
namespace Otus.HomeWork.RE
{
    class MyFileDownloader

    {
        private readonly WebClient _webClient;
        public MyFileDownloader (WebClient webClient) 
        {
            _webClient = webClient;
        }
        public void DownloadFilesFromWeb(Dictionary<string, string> Files, string Host, string Path)
        {
            System.IO.Directory.CreateDirectory(Path);
            foreach (KeyValuePair<string, string> file in Files)
            {
                try
                {
                    _webClient.DownloadFile(file.Key, Path +@"\"+ file.Value);
                }
                catch (Exception)
                {
                    try
                    {
                        _webClient.DownloadFile(Host + file.Key, Path+ @"\" + file.Value);
                    }
                    catch(Exception)
                    {
                        try
                        {
                            _webClient.DownloadFile("Https:" + file.Key, Path + @"\" + file.Value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось скачать файл по ссылке: {0}", "Https:" + file.Key);
                        }                        
                    }
                }
            }

        }

    }
}
