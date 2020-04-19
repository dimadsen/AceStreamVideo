using System.Collections.Generic;

namespace AceStream.Dto
{
    public class ChampionatDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Tour { get; set; }

        public string Image { get; set; }

        public List<MatchPreviewDto> Matches { get; set; }
    }
}
