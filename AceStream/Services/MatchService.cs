using System;
using AceStream.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        public async Task<List<LinkDto>> GetLinksAsync(string[] parameter)
        {
            var links = new List<LinkDto>
            {
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 1" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч ТВ" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 2" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 3" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч Арена" },
            };

            var task = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(2000), new CancellationToken());

                return links;
            });

            return await task;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var match = new MatchDto
            {
                Date = DateTime.Now,
                Half = "1-ый тайм",
                Home = "Вест Хэм",
                ImageHome = "west.png",
                Visitor = "Бормут",
                ImageVisitor = "bourenm.png",
                Score = "1 - 0",
                HomeSquard = new TeamDto
                {
                    Startings = new List<PlayerDto>
                    {
                         new PlayerDto { FirstName = "Лукаш", LastName = "Фабьяньский", Number = "1", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Дэвид", LastName = "Мартин", Number = "22", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Даррен", LastName = "Рэндолф", Number = "18", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Уинстон", LastName = "Рид", Number = "4", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Аарон", LastName = "Крессуэлл", Number = "13", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Фабьян", LastName = "Бальбуэна", Number = "21", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Пабло", LastName = "Сабалета", Number = "44", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Гонсалу", LastName = "Кардозу", Number = "11", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Анджело", LastName = "Огбонна", Number = "9", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Исса", LastName = "Дьоп", Number = "7", Flag = "51_medium.png"},
                         new PlayerDto { FirstName = "Райан", LastName = "Джонсон", Number = "5", Flag = "51_medium.png"}
                    },

                    Substitutes = new List<PlayerDto>
                    {
                        new PlayerDto { FirstName = "Солли", LastName = "Марч", Number = "20", Flag = "51_medium.png"},
                        new PlayerDto { FirstName = "Стивен", LastName = "Альсате", Number = "33", Flag = "51_medium.png"},
                        new PlayerDto { FirstName = "Хосе", LastName = "Хосе", Number = "7", Flag = "51_medium.png"}
                    }

                },
                VisitorSquard = new TeamDto
                {
                    Startings = new List<PlayerDto>
                    {
                        new PlayerDto { FirstName = "Фелипе", LastName = "Андерсон", Number = "31", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Мануэль", LastName = "Лансини", Number = "20", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Роберт", LastName = "Снодграсс", Number = "70", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Карлос", LastName = "Санчес", Number = "18", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Марк", LastName = "Нобл", Number = "4", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Пабло", LastName = "Форнальс", Number = "3", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Джек", LastName = "Уилшир", Number = "11", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Деклан", LastName = "Райс", Number = "10", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Бернардо", LastName = "Роза", Number = "99", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Андрей", LastName = "Ярмоленко", Number = "88", Flag = "35_medium.png"},
                        new PlayerDto { FirstName = "Альбиан", LastName = "Альбиан", Number = "3", Flag = "35_medium.png"}
                    },

                    Substitutes = new List<PlayerDto>
                    {
                       new PlayerDto { FirstName = "Аарон", LastName = "Искьердо", Number = "27", Flag = "35_medium.png"},
                       new PlayerDto { FirstName = "Гленн", LastName = "Коннолли", Number = "30", Flag = "35_medium.png"},
                       new PlayerDto { FirstName = "Нил", LastName = "Мопе", Number = "31", Flag = "35_medium.png" },
                       new PlayerDto { FirstName = "Гай", LastName = "Плеши", Number = "66", Flag = "35_medium.png" },
                       new PlayerDto { FirstName = "Пихаил", LastName = "Мореченков", Number = "12", Flag = "35_medium.png" },
                    }
                },
            };

            var task = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(2000), new CancellationToken());

                return match;
            });

            return await task;
        }        
    }

    public interface IMatchService
    {
        Task<MatchDto> GetMatchAsync(int matchId);

        /// <param name="parameter">Название канала, команды и т.д.</param>
        Task<List<LinkDto>> GetLinksAsync(string[] parameter);
    }
}
