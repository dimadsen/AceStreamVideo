using System.Threading.Tasks;
using AceStream.Core.Domain.Match;
using AceStream.Core.Domain.MatchInfo;
using AceStream.Core.Domain.Tournament;

namespace AceStream.Services.Clients
{
    public interface IClient
    {
        Task<Championat[]> GetChampionatsAsync();
        Task<Core.Domain.MatchInfo.MatchInfo> GetMatchInfoAsync(int matchId);
        Task<Match> GetTeamsAsync(int matchId);
        Task<MatchProgress> GetMatchProgressAsync(int matchId);
    }
}
