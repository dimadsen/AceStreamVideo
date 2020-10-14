using System.Threading.Tasks;
using AceStream.Core.Domain.Match;
using AceStream.Core.Domain.MatchInfo;
using AceStream.Core.Domain.Tournament;
using AceStream.Infrastructure.Parser;
using AceStream.Services.Repositories;
using AceStream.Infrastructure.Parser.Match;

namespace AceStream.Infrastructure.Client
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

        public async Task<Core.Domain.MatchInfo.MatchInfo> GetMatchInfoAsync(int id)
        {
            var url = "core/stat/match/online/?args={%22id%22:" + id + "}";

            var matchInfo = await SendGetRequest<Core.Domain.MatchInfo.MatchInfo>(url);

            return matchInfo;
        }

        public async Task<Core.Domain.Match.Match> GetTeamsAsync(int id)
        {
            var url = $"stat/api/v1/match/{id}/arrange.json";

            var teams = await SendGetRequest<Parser.Match.Match>(url);

            ///Здесь маппинг в доменную модель
            return teams;
        }
    }
}
