using AceStream.Dto;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        public string Title => "Чемпионаты";

        public ChampionatDto[] GetChampionats()
        {
            return new ChampionatDto[]
            {
               new ChampionatDto { Name = "Английская Премьер-Лига", Tour = "Тур 1", Image = "lolo_epl.png" },
               new ChampionatDto { Name = "Серия А", Tour = "Тур 2", Image = "seria-a.png" }
            };
        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        ChampionatDto[] GetChampionats();
    }
}
