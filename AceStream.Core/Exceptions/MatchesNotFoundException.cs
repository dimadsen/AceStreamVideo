using System;
namespace AceStream.Core.Exceptions
{
    public class MatchesNotFoundException : Exception
    {
        public MatchesNotFoundException(string message = "Матчи не найдены") : base(message)
        {
        }
    }
}
