using AceStream.Services.Dto.Enums;

namespace AceStream.Dto
{
    public class MatchPreviewDto
    {
        public string Home { get; set; }

        public string Visitor { get; set; }

        public string HomePicture { get; set; }

        public string VisitorPicture { get; set; }

        public string Time { get; set; }

        public MatchStatus Status { get; set; }

        public string HomeScore { get; set; }

        public string VisitorScore { get; set; }

        public int Id { get; set; }
    }
}
