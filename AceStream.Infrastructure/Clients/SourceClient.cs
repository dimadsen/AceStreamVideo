using System;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Clients;
using AutoMapper;
using System.Linq;
using AceStream.Infrastructure.SportsRuParser.Enums;
using System.Globalization;
using AceStream.Services.Extansions;
using AceStream.Core.Domain.Enums;
using System.Collections.Generic;
using AceStream.Services.Dto;

namespace AceStream.Infrastructure.Clients
{
    public class SourceClient : ISourceClient
    {
        private readonly ISportsRuClient _client;
        private readonly IMapper _mapper;

        public SourceClient(ISportsRuClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var result = await _client.GetChampionatsAsync();

            var championatsIds = Enum.GetValues(typeof(Championship)).Cast<int>();

            var championats =  result.Teaser.Championats
                .Where(c => championatsIds.Contains(c.Id))
                .Select(c=> _mapper.Map<ChampionatDto>(c))
                .Distinct()
                .ToList();

            return championats;
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            var championat = (await _client.GetChampionatsAsync()).Teaser.Championats
                .FirstOrDefault(x => x.Id == championatId);

            var matches = championat.Matches.Select(x => _mapper.Map<MatchPreviewDto>(x)).ToList();

            return matches;
        }


        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var matchInfo = await _client.GetMatchInfoAsync("{%22id%22:" + matchId + "}");

            var match = await _client.GetMatchAsync(matchId);

            var matchDto = new MatchDto
            {
                Id = matchId,
                Date = DateTime.Parse(matchInfo.Date.StartDate, CultureInfo.GetCultureInfo("ru")),
                Half = matchInfo.Status,
                Score = matchInfo.Score,
                Minute = match.Time.Split(0, ":"),
                Status = (MatchStatus)match.Status,
                Stadium = matchInfo.Stadium.Name,
                Channels = matchInfo.Channels.Select(c => c.Name).ToArray(),
                Home = matchInfo.Home.Name,
                ImageHome = matchInfo.Home.Avatar.Icon,
                Visitor = matchInfo.Visitor.Name,
                ImageVisitor = matchInfo.Visitor.Avatar.Icon,
            };

            return matchDto;
        }

        public async Task<SquardDto> GetSquardsAsync(int matchId)
        {
            var squards = await _client.GetMatchAsync(matchId);

            return _mapper.Map<SquardDto>(squards);
        }
    }
}
