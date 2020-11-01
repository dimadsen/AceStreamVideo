using System;
using System.Collections.Generic;
using AceStream.Core.Domain.Enums;

namespace AceStream.Dto
{
    public class MatchDto
    {
        /// <summary>
        /// Название команды хозяев
        /// </summary>
        public string Home { get; set; }

        /// <summary>
        /// Название команды гостей
        /// </summary>
        public string Visitor { get; set; }

        /// <summary>
        /// Счёт
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// Дата матча
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Эмблема хозяев
        /// </summary>
        public string ImageHome { get; set; }

        /// <summary>
        /// Эмблема гостей
        /// </summary>
        public string ImageVisitor { get; set; }

        /// <summary>
        /// Тайм
        /// </summary>
        public string Half { get; set; }

        /// <summary>
        /// Минута
        /// </summary>
        public string Minute { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public MatchStatus Status { get; set; }

        /// <summary>
        /// Состав хозяев
        /// </summary>
        public TeamDto HomeSquard { get; set; }

        /// <summary>
        /// Состав гостей
        /// </summary>
        public TeamDto VisitorSquard { get; set; }

        /// <summary>
        /// Cтадион
        /// </summary>
        public string Stadium { get; set; }

        /// <summary>
        /// Каналы
        /// </summary>
        public string[] Channels { get; set; }
    }
}
