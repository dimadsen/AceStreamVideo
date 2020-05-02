using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.Tests
{
    
    public class ChampionatTests
    {
        [Test]
        public void GetChampionatsTest()
        {
            var client = new Client.Client();
            var championats = Task.Run(async () => await client.GetChampionatsAsync()).Result;            
        }

        [Test]
        public void GetMatchInfoTest()
        {
            var client = new Client.Client();

            var mathInfo = Task.Run(async () => await client.GetMatchInfoAsync(1404469)).Result;

        }

        [Test]
        public void GetTeamsTest()
        {
            var client = new Client.Client();

            var teams = Task.Run(async () => await client.GetTeamsAsync(1404469)).Result;
        }
    }
}
