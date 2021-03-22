using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Net;


namespace App.Service
{
    public class WebScraperService
    {
        private static Dictionary<string, HashSet<string>> validationCache = new Dictionary<string, HashSet<string>>();



        public async Task<string> Start(string url)
        {
            var response =  await CallUrl(url);
            var pageBody =  ParseHtml(url, response);

            return pageBody;
        }

        public async Task<string> Step(string current, string step)
        {
            HashSet<string> validSteps;
            string actual;
            if (validationCache.TryGetValue(current, out validSteps) && validSteps.TryGetValue(step, out actual))
            {
                var response = await CallUrl(step);
                var pageBody = ParseHtml(step, response);

                return pageBody;
            }
            return null;
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

        private static string ParseHtml(string url, string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[@id='bodyContent']");
            var htmlLinks = htmlBody.Descendants("a").ToList();

            HashSet<string> wikiLinks = new HashSet<string>();

            foreach(var link in htmlLinks)
            {
                wikiLinks.Add(link.GetAttributeValue("href", null));
            }

            validationCache.Add(url, wikiLinks);

            return htmlBody.OuterHtml;
        }
    }
}
