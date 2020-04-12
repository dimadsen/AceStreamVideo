using System;
using System.Globalization;
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
        public void GetMatchTest()
        {
            var client = new Client();

            var result = Task.Run(async () => await client.GetMatchInfoAsync("300216/online/se/?json=1")).Result;

        }

        [Test]
        public void SetMatch()
        {
            var presenter = new Mock<IMatchPresenter>();
            var interactor = new MatchInteractor(presenter.Object);

            var result = Task.Run(async () => await interactor.GetMatchAsync(1)).Result;

        }

        [Test]
        public void DateTimeParse()
        {
            var date = "12.04.2020 15:00";

            try
            {
                var d = DateTime.Parse(date, CultureInfo.GetCultureInfo("ru"));
            }
            catch (Exception ex)
            {

            }

        }
    }
}
