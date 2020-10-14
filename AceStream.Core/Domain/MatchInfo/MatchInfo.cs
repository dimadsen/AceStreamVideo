namespace AceStream.Core.Domain.MatchInfo
{
    public class MatchInfo
    {
        public Date Date { get; set; }

        public string Status { get; set; }

        public string Score { get; set; }

        public Team Home { get; set; }

        public Team Visitor { get; set; }

        public Stadium Stadium { get; set; }

        public Channel[] Channels { get; set; }
    }

    public class Date
    {
        public string StartDate { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }

        public Avatar Avatar { get; set; }
    }

    public class Avatar
    {
        public string Icon { get; set; }
    }

    public class Stadium
    {
        public string Name { get; set; }
    }

    public class Channel
    {
        public string Name { get; set; }
    }
}
