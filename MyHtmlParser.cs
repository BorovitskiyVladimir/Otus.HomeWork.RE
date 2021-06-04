using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Otus.HomeWork.RE
{
    class MyHtmlParser
    {
        public Dictionary<string, string> GetImageListFromHtml(string html)
        { Dictionary<string, string> links = new Dictionary<string, string>();
            
            Regex regex = new Regex(@"<img.*src=[\''""](\S+.(jpg|png|gif))");
            MatchCollection res = regex.Matches(html);
            if (res.Count > 0)
            {
               foreach (Match match in res)
                {
                    Regex reNames = new Regex(@"[^\/]+.(jpg|png|gif)");
                    MatchCollection name = reNames.Matches(match.ToString());
                    if (name.Count == 1)
                        try
                        { 
                            links.Add(match.Groups[1].Value.ToString(), name[0].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                }
            }
            return links;
        }
    }       
}
