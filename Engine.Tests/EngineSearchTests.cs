using System;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Engine.Tests
{
    public class EngineSearchTests
    {
        [Test]
        public void SearchTest()
        {
            var client = new EngineClient();

            var results = Task.Run(async () => await client.GetInfoHashAsync("динамо")).Result;

        }

        [Test]
        public void InfohashTest()
        {
            var client = new EngineClient();

            var results = Task.Run(async () => await client.GetPlaybackUrl("35c4a841c54efdde2f57860c87759c3d836fa49e")).Result;

        }
    }
}
