using System;
using System.Threading.Tasks;
using Parser.Models.Match;

namespace Parser.Client
{
    public class Client : BaseClient
    {
        protected override string _baseUrl => "https://www.sport-express.ru/services/match/football";
        
        public async Task<Match> GetMatchInfoAsync(string url)
        {
            var match = await SendGetRequest<Match>(url);

            return match;
        }

    }


}
