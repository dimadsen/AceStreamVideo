using System;
namespace AceStream.Core.Exceptions
{
    public class PlayersNotFoundException : Exception
    {
        public PlayersNotFoundException(string message = "Составы команд не опубликованы") : base(message)
        {
        }
    }
}
