using System;
using System.Text.RegularExpressions;
using AceStream.Dto;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        public MatchDto GetMatch(int matchId)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMatchService
    {
        MatchDto GetMatch(int matchId);
    }
}
