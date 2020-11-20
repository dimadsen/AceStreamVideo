using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Services.Interfaces
{
    public interface IChampionatService
    {
        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
