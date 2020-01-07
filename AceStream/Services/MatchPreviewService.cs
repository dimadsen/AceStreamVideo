using System;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;

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

        public MatchPreviewSettingsDto GetSettings(int championatId)
        {
            MatchPreviewSettingsDto settings = null;

            if (championatId == 0)
            {
                settings = new MatchPreviewSettingsDto
                {
                    Image = "lolo_epl.png",
                    Title = "Премьер-Лига"
                };
            }
            else if (championatId == 1)
            {
                settings = new MatchPreviewSettingsDto
                {
                    Image = "seria-a.png",
                    Title = "Серия А"
                };
            }

            return settings;
        }
    }

    public interface IMatchPreviewService
    {
        MatchPreviewDto[] GetMatches(int championatId);
        MatchPreviewSettingsDto GetSettings(int championatId);
    }
}
