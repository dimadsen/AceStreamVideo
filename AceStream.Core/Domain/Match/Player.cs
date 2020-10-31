using System;

namespace AceStream.Core.Domain.Match
{
    public class Player
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public Flag[] Flag { get; set; }

        /// <summary>
        /// Был заменён?
        /// </summary>
        public bool IsReplacement { get; set; }

        /// <summary>
        /// Имя и минута кем заменён
        /// </summary>
        public string Replacement { get; set; }

        /// <summary>
        /// Имя и минута кого заменил
        /// </summary>
        public string Replaced { get; set; }
    }

    public class Flag
    {
        public string Country { get; set; }
    }
}
