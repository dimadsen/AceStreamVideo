using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AceStream.Infrastructure.Clients;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using NUnit.Framework;
using Refit;

namespace AceStream.Modules.Tests
{
    public class MappingsTests
    {
        private ISportsRuClient _client;

        [SetUp]
        public void Init()
        {
            var settings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            _client = RestService.For<ISportsRuClient>("https://www.sports.ru", settings);
        }

        [Test]
        public void ChampionatTest()
        {
            try
            {
                var matchId = 1512052;
                var par = "{%22id%22:" + matchId + "}";

                var res = _client.GetMatchInfoAsync(par).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [Test]
        public void GetMatches()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var address = "http://livetv.sx/allupcomingsports/1/";

            var document = context.OpenAsync(address).GetAwaiter().GetResult();

            var allMatches = document.GetElementsByClassName("live")
                .OfType<IHtmlAnchorElement>()
                .Select(x => new
                {
                    Path = x.PathName,
                    MatchName = x.Text
                })
                .ToList();
        }

        [Test]
        public void GetLinks()
        {

            var url = "eventinfo/51245037_";

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var address = $"http://livetv.sx/{url}";

            var document = context.OpenAsync(address).GetAwaiter().GetResult();

            var element = document.GetElementById("links_block");

            var links = new List<string>();

            GetLinks(element.Children, links);

        }

        private void GetLinks(IHtmlCollection<IElement> elements, List<string> allLinks)
        {
            foreach (var element in elements)
            {
                var key = "acestream://";

                var links = elements.OfType<IHtmlAnchorElement>()
                    .Where(x => x.Href.Contains(key))
                    .Select(x => x.Href.Replace(key, string.Empty))
                    .ToList();

                allLinks.AddRange(links);

                if (element.Children.Any())
                    GetLinks(element.Children, allLinks);
            }
        }
    }
}
