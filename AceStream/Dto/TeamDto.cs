using System;
using System.Collections.Generic;

namespace AceStream.Dto
{
    public class TeamDto
    {
        /// <summary>
        /// Старовый состав
        /// </summary>
        public List<PlayerDto> Startings { get; set; }

        /// <summary>
        /// Запас
        /// </summary>
        public List<PlayerDto> Substitutes { get; set; }
    }
}
