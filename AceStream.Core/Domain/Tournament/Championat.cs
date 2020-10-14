namespace AceStream.Core.Domain.Tournament
{
    public class Championat
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Country { get; set; }

        public Sport Sport { get; set; }

        public MatchInfo[] Matches { get; set; }
    }

    public class Sport
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
