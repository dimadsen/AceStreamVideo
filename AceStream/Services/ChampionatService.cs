using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        public string Title => "Чемпионаты";

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championats = new List<ChampionatDto>
            {
               new ChampionatDto { Name = "Английская Премьер-Лига", Tour = "Тур 1", Image = "lolo_epl.png" },
               new ChampionatDto { Name = "Серия А", Tour = "Тур 2", Image = "seria-a.png" }
            };

            var task = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(2000), new CancellationToken());

                return championats;
            });

            return await task;
        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
