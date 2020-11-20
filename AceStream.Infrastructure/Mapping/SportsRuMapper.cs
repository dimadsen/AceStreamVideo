using AceStream.Core.Extansions;
using AceStream.Infrastructure.SportsRuParser.Enums;
using AceStream.Services.Extansions;
using AutoMapper;

namespace AceStream.Infrastructure.Mapping
{
    public static class SportsRuMapper
    {
        private static Mapper _mapper;

        static SportsRuMapper()
        {
            var config = new MapperConfiguration(cnf =>
            {
                cnf.CreateMap<SportsRuParser.Tournament.Championat, Core.Domain.Tournament.Championat>()
                .ForMember(dest => dest.Tour, opt => opt.MapFrom(c => c.Name.Split(2, ". ")))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(c => ((Championship)c.Id).GetDescription()))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(c => ((Championship)c.Id).ToString()));

                cnf.CreateMap<SportsRuParser.Tournament.Date, Core.Domain.Tournament.Date>();
                cnf.CreateMap<SportsRuParser.Tournament.MatchInfo, Core.Domain.Tournament.MatchInfo>();
                cnf.CreateMap<SportsRuParser.Tournament.Sport, Core.Domain.Tournament.Sport>();
                cnf.CreateMap<SportsRuParser.Tournament.Status, Core.Domain.Tournament.Status>();
                cnf.CreateMap<SportsRuParser.Tournament.Team, Core.Domain.Tournament.Team>();
                cnf.CreateMap<SportsRuParser.Tournament.Teaser, Core.Domain.Tournament.Teaser>();
                cnf.CreateMap<SportsRuParser.Tournament.Tournament, Core.Domain.Tournament.Tournament>();

                cnf.CreateMap<SportsRuParser.Match.Flag, Core.Domain.Match.Flag>();
                cnf.CreateMap<SportsRuParser.Match.Match, Core.Domain.Match.Match>();
                cnf.CreateMap<SportsRuParser.Match.Player, Core.Domain.Match.Player>();
                cnf.CreateMap<SportsRuParser.Match.Team, Core.Domain.Match.Team>();

                cnf.CreateMap<SportsRuParser.MatchInfo.Avatar, Core.Domain.MatchInfo.Avatar>();
                cnf.CreateMap<SportsRuParser.MatchInfo.Channel, Core.Domain.MatchInfo.Channel>();
                cnf.CreateMap<SportsRuParser.MatchInfo.Date, Core.Domain.MatchInfo.Date>();
                cnf.CreateMap<SportsRuParser.MatchInfo.MatchInfo, Core.Domain.MatchInfo.MatchInfo>();
                cnf.CreateMap<SportsRuParser.MatchInfo.Stadium, Core.Domain.MatchInfo.Stadium>();
                cnf.CreateMap<SportsRuParser.MatchInfo.Team, Core.Domain.MatchInfo.Team>();
            });

            _mapper = new Mapper(config);
        }

        public static TDestination Map<TSource, TDestination>(TSource model)
        {
            return _mapper.Map<TSource, TDestination>(model);
        }
    }
}
