using AceStream.iOS.Modules.ChampionatModule;
using AceStream.Services;
using Moq;
using NUnit.Framework;

namespace AceStream.iOS.Modules.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var presenter = new Mock<IChampionatPresenter>();
            var service = new Mock<IChampionatService>();

            var interactor = new ChampionatInteractor(presenter.Object, service.Object);

            service.VerifyAll();
        }
    }
}