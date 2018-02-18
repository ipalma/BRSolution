using Models.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class NewsArticlesService 
    {

        private readonly HttpClient _dataClient = new HttpClient();
        public async Task<List<Article>> GetList(string searchStr)
        {
            HttpResponseMessage response = await _dataClient.GetAsync(searchStr);
            string Url = string.Empty;
            string ApiKey = string.Empty;
            if (!response.IsSuccessStatusCode) throw new InvalidOperationException(response.RequestMessage.ToString());

            WebRequest cl;
            string requestUrl = string.Empty;
            List<Article> data = new List<Article>();

            if (!string.IsNullOrEmpty(searchStr))
                requestUrl = string.Concat(Url, searchStr, "&api-key=", ApiKey);
            else
                requestUrl = string.Concat(Url, "&api-key=", ApiKey);
            
            cl = WebRequest.Create(requestUrl);
            cl.Method = "GET";
            WebResponse res = cl.GetResponse();

            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    
                    var jObjResult = JObject.Parse(result);
                    data = jObjResult["response"]["results"].ToObject<List<Article>>();
                    
                }
            }

            return data;
        }

    }
}
