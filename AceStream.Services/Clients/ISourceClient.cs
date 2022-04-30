using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Dto;

namespace AceStream.Services.Clients
{
    public interface ISourceClient
    {
        /// <summary>
        /// Получить список чемпионатов
        /// </summary>
        /// <returns></returns>
        Task<List<ChampionatDto>> GetChampionatsAsync();

        /// <summary>
        /// Получить матчи чемпионата
        /// </summary>
        /// <param name="championatId"></param>
        /// <returns></returns>
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        /// <summary>
        /// Получить инфо по матчу
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        Task<MatchDto> GetMatchAsync(int matchId);

        /// <summary>
        /// Получить составы
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        Task<SquardDto> GetSquardsAsync(int matchId);
    }
}
