﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Services.Extansions;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services.Repositories;

namespace AceStream.Services
{
    public class MatchPreviewService : IMatchPreviewService
    {
        public MatchPreviewService()
        {
            
        }
        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            var task = Task.Run(() =>
            {
                //var matches = _db.GetMatches(championatId).Where(m => DateTime.Parse(m.Date).Date == DateTime.Now.Date).ToList();

                //var dto = matches.Select(m => new MatchPreviewDto
                //{
                //    ValueId = m.ValueId,
                //    Home = m.Home,
                //    HomePicture = m.HomeIcon,
                //    HomeScore = m.Score.Split(0, ":"),
                //    Time = DateTime.Parse(m.Date).ToString("HH:mm"),
                //    Status = m.Status,
                //    Visitor = m.Visitor,
                //    VisitorPicture = m.VisitorIcon,
                //    VisitorScore = m.Score.Split(1, ":"),
                //}).ToList();

                return new List<MatchPreviewDto>();
            });

            return await task;
        }

        public MatchPreviewSettingsDto GetSettings(int championatId)
        {
            //var championat = _db.GetChampionat(championatId);

            //var settings = new MatchPreviewSettingsDto()
            //{
            //    Image = championat.Icon,
            //    Title = championat.ShortName
            //};

            return new MatchPreviewSettingsDto { };
        }
    }

    public interface IMatchPreviewService
    {
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(int championatId);
    }
}
