using System.Threading.Tasks;
using AceStream.Core.Domain.Tournament;
using AceStream.Services.Repositories;
using AceStream.Infrastructure.Mapping;
using System.Linq;

using System;
using AceStream.Infrastructure.Parser.Enums;

namespace AceStream.Infrastructure.Client
{
    public class Client : BaseClient, IClient
    {
        protected override string _baseUrl => "https://www.sports.ru/";

        public async Task<Championat[]> GetChampionatsAsync()
        {
            var url = "core/stat/match/teaser/";

            var tournament = await SendGetRequest<Parser.Tournament.Tournament>(url);

            var result = Mapper.Map<Parser.Tournament.Tournament, Tournament>(tournament);

            var championships = Enum.GetValues(typeof(Championship)).Cast<int>();

            return result.Teaser.Championats.Where(c => championships.Contains(c.Id)).ToArray();
        }

        public async Task<Core.Domain.MatchInfo.MatchInfo> GetMatchInfoAsync(int id)
        {
            var url = "core/stat/match/online/?args={%22id%22:" + id + "}";

            var matchInfo = await SendGetRequest<Parser.MatchInfo.MatchInfo>(url);

            var result = Mapper.Map<Parser.MatchInfo.MatchInfo, Core.Domain.MatchInfo.MatchInfo>(matchInfo);

            return result;
        }

        public async Task<Core.Domain.Match.Match> GetTeamsAsync(int id)
        {
            var url = $"stat/api/v1/match/{id}/arrange.json";

            var match = await SendGetRequest<Parser.Match.Match>(url);

            var result = Mapper.Map<Parser.Match.Match, Core.Domain.Match.Match>(match);

            return result;
        }
    }
}
