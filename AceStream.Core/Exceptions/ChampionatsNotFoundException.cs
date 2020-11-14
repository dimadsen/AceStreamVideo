using System;
namespace AceStream.Core.Exceptions
{
    public class ChampionatsNotFoundException : Exception
    {
        public ChampionatsNotFoundException(string message = "На сегодня матчей нет") : base(message)
        {
        }
    }
}
