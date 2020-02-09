using System;
using System.Collections.Generic;

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
        /// Состав хозяев
        /// </summary>
        public List<SquardDto> HomeSquard { get; set; }

        /// <summary>
        /// Состав гостей
        /// </summary>
        public List<SquardDto> VisitorSquard { get; set; }

        /// <summary>
        /// Ссылки на трансляции
        /// </summary>
        public List<LinkDto> Links { get; set; }
    }
}
