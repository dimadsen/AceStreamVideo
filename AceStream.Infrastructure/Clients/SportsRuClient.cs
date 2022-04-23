using System.Threading.Tasks;
using AceStream.Core.Domain.Tournament;
using AceStream.Services.Clients;
using System.Linq;
using System;
using AceStream.Infrastructure.SportsRuParser.Enums;
using static AceStream.Infrastructure.Mapping.SportsRuMapper;

namespace AceStream.Infrastructure.Clients
{
    public class SportsRuClient : BaseClient, IClient
    {
        protected override string _baseUrl => "https://www.sports.ru/";

        public async Task<Championat[]> GetChampionatsAsync()
        {
            var url = "core/stat/match/teaser/";

            var tournament = await SendGetRequest<SportsRuParser.Tournament.Tournament>(url);

            var result = Map<SportsRuParser.Tournament.Tournament, Tournament>(tournament);

            var championships = Enum.GetValues(typeof(Championship)).Cast<int>();

            return result.Teaser.Championats.Where(c => championships.Contains(c.Id)).ToArray();
        }

        public async Task<Core.Domain.MatchInfo.MatchInfo> GetMatchInfoAsync(int id)
        {
            var url = "core/stat/match/online/?args={%22id%22:" + id + "}";

            var matchInfo = await SendGetRequest<SportsRuParser.MatchInfo.MatchInfo>(url);

            var result = Map<SportsRuParser.MatchInfo.MatchInfo, Core.Domain.MatchInfo.MatchInfo>(matchInfo);

            return result;
        }

        public async Task<Core.Domain.Match.MatchProgress> GetMatchProgressAsync(int matchId)
        {
            var url = $"stat/api/v1/match/{matchId}/arrange.json";

            var matchProgress = await SendGetRequest<Parsers.SportsRuParser.Match.Progress>(url);

            var result = Map<Parsers.SportsRuParser.Match.Progress, Core.Domain.Match.MatchProgress>(matchProgress);

            return result;

        }

        public async Task<Core.Domain.Match.Match> GetTeamsAsync(int matchId)
        {
            var url = $"stat/api/v1/match/{matchId}/arrange.json";

            var match = await SendGetRequest<SportsRuParser.Match.Match>(url);

            var result = Map<SportsRuParser.Match.Match, Core.Domain.Match.Match>(match);

            return result;
        }
    }
}
