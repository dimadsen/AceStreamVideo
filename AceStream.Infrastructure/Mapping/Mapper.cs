using AutoMapper;

namespace AceStream.Infrastructure.Mapping
{
    public static class Mapper
    {
        private static AutoMapper.Mapper _mapper;

        static Mapper()
        {
            var config = new MapperConfiguration(cnf =>
            {                
                cnf.CreateMap<Parser.Tournament.Championat, Core.Domain.Tournament.Championat>();
                cnf.CreateMap<Parser.Tournament.Date, Core.Domain.Tournament.Date>();
                cnf.CreateMap<Parser.Tournament.MatchInfo, Core.Domain.Tournament.MatchInfo>();
                cnf.CreateMap<Parser.Tournament.Sport, Core.Domain.Tournament.Sport>();
                cnf.CreateMap<Parser.Tournament.Status, Core.Domain.Tournament.Status>();
                cnf.CreateMap<Parser.Tournament.Team, Core.Domain.Tournament.Team>();
                cnf.CreateMap<Parser.Tournament.Teaser, Core.Domain.Tournament.Teaser>();
                cnf.CreateMap<Parser.Tournament.Tournament, Core.Domain.Tournament.Tournament>();

                cnf.CreateMap<Parser.Match.Flag, Core.Domain.Match.Flag>();
                cnf.CreateMap<Parser.Match.Match, Core.Domain.Match.Match>();
                cnf.CreateMap<Parser.Match.Player, Core.Domain.Match.Player>();
                cnf.CreateMap<Parser.Match.Team, Core.Domain.Match.Team>();

                cnf.CreateMap<Parser.MatchInfo.Avatar, Core.Domain.MatchInfo.Avatar>();
                cnf.CreateMap<Parser.MatchInfo.Channel, Core.Domain.MatchInfo.Channel>();
                cnf.CreateMap<Parser.MatchInfo.Date, Core.Domain.MatchInfo.Date>();
                cnf.CreateMap<Parser.MatchInfo.MatchInfo, Core.Domain.MatchInfo.MatchInfo>();
                cnf.CreateMap<Parser.MatchInfo.Stadium, Core.Domain.MatchInfo.Stadium>();
                cnf.CreateMap<Parser.MatchInfo.Team, Core.Domain.MatchInfo.Team>();
            });

            _mapper = new AutoMapper.Mapper(config);
        }

        public static M Map<T,M>(T model)
        {
            return _mapper.Map<T, M>(model);
        }
    }
}
