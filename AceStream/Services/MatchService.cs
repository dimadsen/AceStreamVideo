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
                    new SquardDto { FirstName = "Лукаш", LastName = "Фабьяньский", Number = "1"},
                    new SquardDto { FirstName = "Дэвид", LastName = "Мартин", Number = "22"},
                    new SquardDto { FirstName = "Даррен", LastName = "Рэндолф", Number = "18"},
                    new SquardDto { FirstName = "Уинстон", LastName = "Рид", Number = "4"},
                    new SquardDto { FirstName = "Аарон", LastName = "Крессуэлл", Number = "13"},
                    new SquardDto { FirstName = "Фабьян", LastName = "Бальбуэна", Number = "21"},
                    new SquardDto { FirstName = "Пабло", LastName = "Сабалета", Number = "44"},
                    new SquardDto { FirstName = "Гонсалу", LastName = "Кардозу", Number = "11"},
                    new SquardDto { FirstName = "Анджело", LastName = "Огбонна", Number = "9"},
                    new SquardDto { FirstName = "Исса", LastName = "Дьоп", Number = "7"},
                    new SquardDto { FirstName = "Райан", LastName = "Джонсон", Number = "5"},
                },

                VisitorSquard = new List<SquardDto>
                {
                    new SquardDto { FirstName = "Фелипе", LastName = "Андерсон", Number = "31"},
                    new SquardDto { FirstName = "Мануэль", LastName = "Лансини", Number = "20"},
                    new SquardDto { FirstName = "Роберт", LastName = "Снодграсс", Number = "70"},
                    new SquardDto { FirstName = "Карлос", LastName = "Санчес", Number = "18"},
                    new SquardDto { FirstName = "Марк", LastName = "Нобл", Number = "4"},
                    new SquardDto { FirstName = "Пабло", LastName = "Форнальс", Number = "3"},
                    new SquardDto { FirstName = "Джек", LastName = "Уилшир", Number = "11"},
                    new SquardDto { FirstName = "Деклан", LastName = "Райс", Number = "10"},
                    new SquardDto { FirstName = "Бернардо", LastName = "Роза", Number = "99"},
                    new SquardDto { FirstName = "Андрей", LastName = "Ярмоленко", Number = "88"},
                    new SquardDto { FirstName = "Альбиан", LastName = "Альбиан", Number = "3"},
                },

                Links = new List<LinkDto>
                {
                    new LinkDto{ Link = "", Name =  "Футбол 1" },
                    new LinkDto{ Link = "", Name =  "Матч ТВ" },
                    new LinkDto{ Link = "", Name =  "Футбол 2" },
                    new LinkDto{ Link = "", Name =  "Футбол 3" },
                    new LinkDto{ Link = "", Name =  "Матч Арена" },
                }
            };
        }
    }

    public interface IMatchService
    {
        MatchDto GetMatch(int matchId);
    }
}
