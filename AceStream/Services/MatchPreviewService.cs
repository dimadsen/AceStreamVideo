using System;
using AceStream.Dto;

namespace AceStream.Services
{
    public class MatchPreviewService : IMatchPreviewService
    {
        public MatchPreviewDto[] GetMatches(int championatId)
        {
            MatchPreviewDto[] matches = null;

            if (championatId == 0)
            {
                matches = new MatchPreviewDto[]
                {
                    new MatchPreviewDto
                    {
                         Home = "Лестер",
                         HomePicture = "lolo_epl.png",
                         Visitor = "Манчестер",
                         VisitorPicture = "seria-a.png",
                         Time = "18:20"
                    },
                    new MatchPreviewDto
                    {
                         Home = "Ливерпуль",
                         HomePicture = "lolo_epl.png",
                         Visitor = "Сити",
                         VisitorPicture = "seria-a.png",
                         Time = "21:45"
                    }
                };
            }

            else if (championatId == 1)
            {
                matches = new MatchPreviewDto[]
                {
                    new MatchPreviewDto
                    {
                         Home = "Ювентус",
                         HomePicture = "lolo_epl.png",
                         Visitor = "Торино",
                         VisitorPicture = "seria-a.png",
                         Time = "14:20"
                    },
                    new MatchPreviewDto
                    {
                         Home = "Интер",
                         HomePicture = "lolo_epl.png",
                         Visitor = "Милан",
                         VisitorPicture = "seria-a.png",
                         Time = "13:45"
                    }
                };
            }

            return matches;

        }
    }

    public interface IMatchPreviewService
    {
        MatchPreviewDto[] GetMatches(int championatId);
    }
}
