using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Parser.Tests
{
    
    public class ChampionatTests
    {
        [Test]
        public void GetChampionats()
        {
            var client = new Client.Client();
            var championats = Task.Run(async () => await client.GetChampionatsAsync()).Result;

            
        }
    }
}
