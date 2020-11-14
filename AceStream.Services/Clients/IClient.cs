using System.Threading.Tasks;
using AceStream.Core.Domain.Match;
using AceStream.Core.Domain.MatchInfo;
using AceStream.Core.Domain.Tournament;

namespace AceStream.Services.Clients
{
    public interface IClient
    {
        Task<Championat[]> GetChampionatsAsync();
        Task<Core.Domain.MatchInfo.MatchInfo> GetMatchInfoAsync(int id);
        Task<Match> GetTeamsAsync(int id);
    }
}
