using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Services.Interfaces
{
    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
