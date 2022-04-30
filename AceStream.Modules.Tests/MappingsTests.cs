using System;
using AceStream.Infrastructure.Clients;
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
    }
}
