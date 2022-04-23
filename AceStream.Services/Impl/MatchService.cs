using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Domain.Enums;
using AceStream.Core.Domain.Match;
using AceStream.Dto;
using AceStream.Services.Extansions;
using AceStream.Services.Clients;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        private IClient _client;

        public MatchService(IClient client)
        {
            _client = client;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var matchInfo = await _client.GetMatchInfoAsync(matchId);

            var progress = await _client.GetMatchProgressAsync(matchId);

            var matchDto = new MatchDto
            {
                Id = matchId,
                Date = DateTime.Parse(matchInfo.Date.StartDate, CultureInfo.GetCultureInfo("ru")),
                Half = matchInfo.Status,                 
                Score = matchInfo.Score,
                Minute = progress.Time.Split(0, ":"),
                Status = (MatchStatus)progress.Status,
                Stadium = matchInfo.Stadium.Name,
                Channels = matchInfo.Channels.Select(c => c.Name).ToArray(),
                Home = matchInfo.Home.Name,
                ImageHome = matchInfo.Home.Avatar.Icon,
                

                Visitor = matchInfo.Visitor.Name,
                ImageVisitor = matchInfo.Visitor.Avatar.Icon,
                
            };

            return matchDto;
        }        
    }
}
