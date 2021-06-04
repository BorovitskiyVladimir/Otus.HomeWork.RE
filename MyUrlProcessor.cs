using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
namespace Otus.HomeWork.RE
{
    public class MyUrlProcessor 
    { 
        private readonly HttpClient _client;
        public  MyUrlProcessor (HttpClient client)
            {
            _client = client;

                }
        public  async Task<string> GetHtmlFromUrl(string url)
        {
            string htmlCode;

            using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        htmlCode = await content.ReadAsStringAsync();
                    }
                }            
            return htmlCode;
        }
    }
}
