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


namespace App.Controllers
{
    //[Route("api/[controller]")]

    [ApiController]
    public class WebScraperController : ControllerBase
    {



        [HttpGet("api/webscraper/{url}")]
        public IActionResult ControllerGetLinks(string url)
        {
            var response =  CallUrl(url).Result;
            var linkList =  ParseHtml(response);

            return Ok(linkList);
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

        private static List<string> ParseHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[@id='bodyContent']");
            var htmlLinks = htmlBody.Descendants("a").ToList();

            List<string> wikiLinks = new List<string>();

            foreach(var link in htmlLinks)
            {
                wikiLinks.Add(link.GetAttributeValue("href", ""));
            }

            return wikiLinks;
            

        }
    }
}
