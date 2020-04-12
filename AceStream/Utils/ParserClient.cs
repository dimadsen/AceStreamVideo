using System;
using Parser.Client;

namespace AceStream.Utils
{
    public class ParserClient : Client
    {
        private static ParserClient _instance;

        public static ParserClient Instance => _instance ?? (_instance = new ParserClient());
    }
}
