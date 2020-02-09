using System;
using System.Text.RegularExpressions;
using AceStream.Dto;
using System.Collections.Generic;
namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        public MatchDto GetMatch(int matchId)
        {
            return new MatchDto
            {
                Date = DateTime.Now,
                Half = "1-ый тайм",
                Home = "Вест Хэм",
                ImageHome = "west.png",
                Visitor = "Бормут",
                ImageVisitor = "bourenm.png",
                Score = "2 - 2",

                HomeSquard = new List<SquardDto>
                {
                    new SquardDto { FirstName = "Лукаш", LastName = "Фабьяньский", Number = "1", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Дэвид", LastName = "Мартин", Number = "22", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Даррен", LastName = "Рэндолф", Number = "18", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Уинстон", LastName = "Рид", Number = "4", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Аарон", LastName = "Крессуэлл", Number = "13", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Фабьян", LastName = "Бальбуэна", Number = "21", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Пабло", LastName = "Сабалета", Number = "44", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Гонсалу", LastName = "Кардозу", Number = "11", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Анджело", LastName = "Огбонна", Number = "9", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Исса", LastName = "Дьоп", Number = "7", Flag = "51_medium.png"},
                    new SquardDto { FirstName = "Райан", LastName = "Джонсон", Number = "5", Flag = "51_medium.png"},
                },

                VisitorSquard = new List<SquardDto>
                {
                    new SquardDto { FirstName = "Фелипе", LastName = "Андерсон", Number = "31", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Мануэль", LastName = "Лансини", Number = "20", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Роберт", LastName = "Снодграсс", Number = "70", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Карлос", LastName = "Санчес", Number = "18", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Марк", LastName = "Нобл", Number = "4", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Пабло", LastName = "Форнальс", Number = "3", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Джек", LastName = "Уилшир", Number = "11", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Деклан", LastName = "Райс", Number = "10", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Бернардо", LastName = "Роза", Number = "99", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Андрей", LastName = "Ярмоленко", Number = "88", Flag = "35_medium.png"},
                    new SquardDto { FirstName = "Альбиан", LastName = "Альбиан", Number = "3", Flag = "35_medium.png"},
                },

                Links = new List<LinkDto>
                {
                    new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 1" },
                    new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч ТВ" },
                    new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 2" },
                    new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 3" },
                    new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч Арена" },
                }
            };
        }
    }

    public interface IMatchService
    {
        MatchDto GetMatch(int matchId);
    }
}
