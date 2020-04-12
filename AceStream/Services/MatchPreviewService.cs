using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;

namespace AceStream.Services
{
    public class MatchPreviewService : IMatchPreviewService
    {
        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            List<MatchPreviewDto> matches = null;

            if (championatId == 0)
            {
                matches = new List<MatchPreviewDto>
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
                matches = new List<MatchPreviewDto>
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

            var task = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500), new CancellationToken());

                return matches;
            });

            return await task;

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
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(int championatId);
    }
}
