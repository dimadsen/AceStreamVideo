namespace AceStream.Core.Domain.Tournament
{
    public class Tournament
    {
        public Teaser Teaser { get; set; }
    }

    public class Teaser
    {
        public Championat[] Championats { get; set; }
    }
}
