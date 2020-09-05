using System;
using System.Collections.Generic;
using AceStream.Core.Entity.Models;

namespace AceStream.Services.Repositories
{
    public interface IDataBase
    {
        List<Championat> GetChampionats();
        Championat GetChampionat(int championatId);
        List<Match> GetMatches(int championatId);
        Match GetMatch(int valueId);
        void SaveMatches(List<Match> matches);
        void SaveMatch(Match match);
        void Update(Match match);
        User GetUser(int id);
        User GetUser(string email, string password);
        bool SaveUser(string name, string email, string password);
    }
}
