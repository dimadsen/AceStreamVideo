using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchDto> GetMatchAsync(int matchId);

        /// <param name="parameter">Название канала, команды и т.д.</param>
        Task<List<LinkDto>> GetLinksAsync(string[] parameter);
    }
}
