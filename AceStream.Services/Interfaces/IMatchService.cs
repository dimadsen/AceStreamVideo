using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchDto> GetMatchAsync(int matchId);
    }
}
