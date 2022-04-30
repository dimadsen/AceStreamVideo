using System;
using System.Linq;
using AceStream.Core.Domain.Enums;
using AceStream.Core.Extansions;
using AceStream.Dto;
using AceStream.Infrastructure.Mapping.Converters;
using AceStream.Infrastructure.SportsRuParser.Enums;
using AceStream.Infrastructure.SportsRuParser.Match;
using AceStream.Infrastructure.SportsRuParser.Tournament;
using AceStream.Services.Dto;
using AceStream.Services.Extansions;
using AutoMapper;

namespace AceStream.Infrastructure.Mapping
{
    public class SportsRuMapperProfile : Profile
    {
        public SportsRuMapperProfile()
        {
            CreateMap<Championat, ChampionatDto>()
                .ForMember(dest => dest.Tour, opt => opt.MapFrom(c => c.Name.Split(2, ". ")))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(c => ((Championship)c.Id).GetDescription()))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(c => ((Championship)c.Id).ToString()));

            CreateMap<MatchInfo, MatchPreviewDto>()
                .ForMember(dest => dest.Home, opt => opt.MapFrom(x => x.Home.Name))
                .ForMember(dest => dest.HomePicture, opt => opt.MapFrom(x => x.Home.Icon))
                .ForMember(dest => dest.HomeScore, opt => opt.MapFrom(x => x.Score.Split(0, ":")))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(x => x.Date.StartDate.ToString("HH:mm")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(x => (MatchStatus)x.Status.Id))
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(x => x.Visitor.Name))
                .ForMember(dest => dest.VisitorPicture, opt => opt.MapFrom(x => x.Visitor.Icon))
                .ForMember(dest => dest.VisitorScore, opt => opt.MapFrom(x => x.Score.Split(1, ":")));

            CreateMap<Match, SquardDto>()
                .ForMember(x => x.HomeSquard, opt => opt.MapFrom(x => x.Teams[0]))
                .ForMember(x => x.VisitorSquard, opt => opt.MapFrom(x => x.Teams[1]));

            CreateMap<Team, TeamDto>()
                .ConvertUsing(new TeamDtoConverter());

            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Flag, opt => opt.MapFrom(x => $"{x.Flag.FirstOrDefault().Country}.png"))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(x => x.Flag.FirstOrDefault().Country));
        }
    }
}
