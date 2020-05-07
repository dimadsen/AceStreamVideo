using System.Threading.Tasks;
using Parser.Models.Match;
using Parser.Models.MatchInfo;

namespace Parser.Client
{
    public class Client : BaseClient
    {
        protected override string _baseUrl => "https://www.sports.ru/";

        public async Task<Tournament.Championat[]> GetChampionatsAsync()
        {
            var url = "core/stat/match/teaser/";

            var tournaments = await SendGetRequest<Tournament.Tournament>(url);

            return tournaments.Teaser.Championats;
        }

        public async Task<MatchInfo> GetMatchInfoAsync(int id)
        {
            var url = "core/stat/match/online/?args={%22id%22:" + id + "}";

            var matchInfo = await SendGetRequest<MatchInfo>(url);

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
