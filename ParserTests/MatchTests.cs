using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Modules.MatchModule;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Parser.Client;

namespace ParserTests
{
    [TestFixture]
    public class MatchTests
    {
        [Test]
        public void GetMatchInfoTest()
        {
            var client = new Client();

            var result = Task.Run(async () => await client.GetMatchInfoAsync("1343738")).Result;

        }

        [Test]
        public void GetTeamsTest()
        {
            var client = new Client();

            var result = Task.Run(async () => await client.GetTeamsAsync("1343738")).Result;
        }

    }
}
