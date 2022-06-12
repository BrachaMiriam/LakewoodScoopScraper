using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hmwrk64.scraping
{
    public static class LakewoodScoop
    {
        public static List<Post> Scrape()
        {
            var html = GetLakewoodScoopHtml();
            return ParseLakewoodScoopHtml(html);
        } 

        private static List<Post> ParseLakewoodScoopHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".post");
            var posts = new List<Post>();
            foreach(var div in resultDivs)
            {
                var post = new Post();

                var titleSpan = div.QuerySelector("h2");
                if (titleSpan != null)
                {
                    post.Title = titleSpan.TextContent;
                }

                var imageTag = div.QuerySelector(".aligncenter");
                if(imageTag != null)
                {
                    post.Image = imageTag.Attributes["src"].Value;
                }

                var comments = div.QuerySelector(".backtotop");
                if(comments != null)
                {
                    post.AmountComments = comments.TextContent;
                }

                var linkTag = div.QuerySelector("a");
                if(linkTag != null)
                {
                    post.Link = $"{linkTag.Attributes["href"].Value}";
                }

                var text = div.QuerySelector("p");
                if(text != null)
                {
                    post.Text = text.TextContent;
                }

                posts.Add(post);

            }

            return posts;
        }

        private static string GetLakewoodScoopHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = $"https://www.thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
