using System;
namespace AceStream.Extansions
{
    public class NotFoundMatchesException : Exception
    {
        public NotFoundMatchesException(string message) : base(message)
        {
        }
    }

    public class NotFoundPlayersException : Exception
    {
        public NotFoundPlayersException(string message) : base(message)
        {
        }
    }
}
