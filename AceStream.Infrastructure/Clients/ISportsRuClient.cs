using System;
using System.Threading.Tasks;
using AceStream.Infrastructure.SportsRuParser.Match;
using AceStream.Infrastructure.SportsRuParser.MatchInfo;
using AceStream.Infrastructure.SportsRuParser.Tournament;
using Refit;

namespace AceStream.Infrastructure.Clients
{
    public interface ISportsRuClient
    {
        [Get("/core/stat/match/teaser/")]
        Task<Tournament> GetChampionatsAsync();

        [Get("/core/stat/match/online/")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<FullMatchInfo> GetMatchInfoAsync([Query]string args);

        [Get("/stat/api/v1/match/{matchId}/arrange.json")]
        Task<Match> GetMatchAsync(int matchId);
    }
}
