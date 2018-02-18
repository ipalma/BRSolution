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
    public class Services<T> : IServices<T>
    {
        public string Url = "https://content.guardianapis.com/search?";
        public string ApiKey = "9a931d2b-c444-4214-a3f5-64a89f0232d4";

        private readonly HttpClient _dataClient = new HttpClient();

        public Services(){}

        public List<T> GetList(string searchStr)
        {

            //HttpResponseMessage response = await _dataClient.GetAsync(searchStr);

            //if (!response.IsSuccessStatusCode) throw new InvalidOperationException(response.RequestMessage.ToString());

            WebRequest cl;
            string requestUrl = string.Empty;
            List<T> data = new List<T>();

            if (!string.IsNullOrEmpty(searchStr))
                requestUrl = string.Concat(Url, "q=",searchStr, "&api-key=", ApiKey);
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
                    data = jObjResult["response"]["results"].ToObject<List<T>>();

                }
            }

            return data;
        }
    }
}
