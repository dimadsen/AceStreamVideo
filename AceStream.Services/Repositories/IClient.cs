using System.Threading.Tasks;
using AceStream.Core.Parser.Match;
using AceStream.Core.Parser.MatchInfo;
using AceStream.Core.Parser.Tournament;

namespace AceStream.Services.Repositories
{
    public interface IClient
    {
        Task<Championat[]> GetChampionatsAsync();
        Task<Core.Parser.MatchInfo.MatchInfo> GetMatchInfoAsync(int id);
        Task<Match> GetTeamsAsync(int id);
    }
}
