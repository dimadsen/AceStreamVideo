using System;
using AceStream.Dto;

namespace AceStream.Services.Dto
{
    public class SquardDto
    {
        /// <summary>
        /// Состав хозяев
        /// </summary>
        public TeamDto HomeSquard { get; set; }

        /// <summary>
        /// Состав гостей
        /// </summary>
        public TeamDto VisitorSquard { get; set; }
    }
}
