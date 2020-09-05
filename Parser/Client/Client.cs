using System.Threading.Tasks;
using AceStream.Core.Parser.Match;
using AceStream.Core.Parser.MatchInfo;
using AceStream.Core.Parser.Tournament;
using AceStream.Services.Repositories;

namespace Parser.Client
{
    public class Client : BaseClient, IClient
    {
        protected override string _baseUrl => "https://www.sports.ru/";

        public async Task<Championat[]> GetChampionatsAsync()
        {
            var url = "core/stat/match/teaser/";

            var tournaments = await SendGetRequest<Tournament>(url);

            return tournaments.Teaser.Championats;
        }

        public async Task<AceStream.Core.Parser.MatchInfo.MatchInfo> GetMatchInfoAsync(int id)
        {
            var url = "core/stat/match/online/?args={%22id%22:" + id + "}";

            var matchInfo = await SendGetRequest<AceStream.Core.Parser.MatchInfo.MatchInfo>(url);

            return matchInfo;
        }

        public async Task<Match> GetTeamsAsync(int id)
        {
            var url = $"stat/api/v1/match/{id}/arrange.json";

            var teams = await SendGetRequest<Match>(url);

            return teams;
        }
    }
}
