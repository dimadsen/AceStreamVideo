using System.Linq;
using AceStream.Dto;
using AceStream.Infrastructure.SportsRuParser.Match;
using AutoMapper;

namespace AceStream.Infrastructure.Mapping.Converters
{
    public class TeamDtoConverter : ITypeConverter<Team, TeamDto>
    {
        public TeamDto Convert(Team source, TeamDto destination, ResolutionContext context)
        {
            var startings = source.Startings
                .Where(x => IsStartings(x))
                .Select(x => context.Mapper.Map<PlayerDto>(x))
                .ToList();

            var substitutes = source.Substitutes
                .SelectMany(p => p.Select(x => context.Mapper.Map<PlayerDto>(x)))
                .ToList();

            var replacements = source.Startings
                .Where(p => !IsStartings(p))
                .Select(p => context.Mapper.Map<PlayerDto>(p))
                .ToList();

            substitutes.AddRange(replacements);

            return new TeamDto
            {
                Startings = startings,
                Substitutes = substitutes
            };
        }

        private bool IsStartings(Player player)
        {
            var isStarting = (!player.IsReplacement && string.IsNullOrEmpty(player.Replaced)) ||
                      (player.IsReplacement && !string.IsNullOrEmpty(player.Replacement));

            return isStarting;
        }
    }
}
