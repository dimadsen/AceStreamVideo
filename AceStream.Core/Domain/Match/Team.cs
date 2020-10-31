using System;

namespace AceStream.Core.Domain.Match
{
    public class Team
    {
        public string Name { get; set; }

        public string Goals { get; set; }

        public string Icon { get; set; }

        public Player[] Startings { get; set; }

        public Player[][] Substitutes { get; set; }

    }
}
