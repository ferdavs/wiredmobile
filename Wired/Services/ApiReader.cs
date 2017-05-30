using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wired.Helpers
{
    // taken from https://forums.xamarin.com/discussion/comment/52352/#Comment_52352
    public class ApiReader
    {
        private static IEnumerable<Item> LoadFromUrlAsync(string url)
        {
            int i = 0;

            using (var webClient = Browser())
            {
                var xmlUrl = new Uri(url);
                var result = webClient.DownloadString(xmlUrl);
                result.Replace("dc:creator", "creator");
                var document = XDocument.Parse(result);

                foreach (var u in document.Descendants("item").Select(u =>
                           new Item
                           {
                               Id = i++,
                               Title = u.Element("title").Value,
                               //Author = u.Element("creator").Value,
                               Link = (u.Element("link").Value),
                               //Content = await LoadContentAsync(u.Element("link").Value),
                               Description = u.Element("description").Value,
                               ImageUrl = GetImageUrl(u.Element("description").Value),
                               PubDate = DateTime.Parse(u.Element("pubDate").Value)
                           })) yield return u;

            }
        }

        private static string LoadContentAsync(string url)
        {
            using (var web = Browser())
            {
                var doc = new HtmlDocument();
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var c = web.DownloadString(url);
                doc.LoadHtml(c);
                var rval = doc.DocumentNode.Descendants("article");
                var ar = rval.First().InnerHtml;
                return ar;
            }
        }

        public async static Task<IEnumerable<Item>> GetFromApi(string url)
        {
            var client = new HttpClient();
            var uri = new Uri(WiredPages.ApiRss.GetString());
            var body = new StringContent(url);
            var response = client.PostAsync(uri, body).Result;
            var s = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Item>>(s);
        }

        private static WebClient Browser()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", WiredPages.UserAgent.GetString());
            client.Headers.Add("Accept", "text/html, application/xhtml+xml");
            //webClient.Headers.Add("Host", "www.wired.com");

            return client;
        }

        private static string Clean(string value)
        {
            var s = value.IndexOf("<", StringComparison.Ordinal);
            if (s >= 0)
            {
                var e = value.IndexOf(">", s, StringComparison.Ordinal);
                if (e >= 0)
                {
                    return value.Remove(s, e - s + 1);
                }
            }
            return "";
        }

        private static string GetImageUrl(string value)
        {
            var s = value.IndexOf("https:", StringComparison.Ordinal);
            if (s >= 0)
            {
                var e = value.IndexOf("\"", s, StringComparison.Ordinal);
                if (e >= 0)
                    return value.Substring(s, e - s);
            }
            return "";
        }
    }
}
