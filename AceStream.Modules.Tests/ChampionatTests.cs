using AceStream.Dto;
using AceStream.iOS.Modules.ChampionatModule;
using AceStream.Services;
using AceStream.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AceStream.iOS.Modules.Tests
{
    public class ChampionatTests
    {
        Mock<IChampionatPresenter> _presenterMock;
        Mock<IChampionatService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _presenterMock = new Mock<IChampionatPresenter>();
            _serviceMock = new Mock<IChampionatService>();
        }

        [Test]
        public void Interactor_ChampionatsNotFound()
        {
            _serviceMock.Setup(x => x.GetChampionatsAsync())
                .ReturnsAsync(() => new List<ChampionatDto>());

            var interactor = new ChampionatInteractor(_presenterMock.Object,
                _serviceMock.Object);

            _ = interactor.GetChampionatsAsync();

            _presenterMock.Verify(x => x.SetNotFoundChampionats(It.IsAny<string>()), "SetNotFoundChampionats должен быть вызван");
        }

        [Test]
        public void Interactor_SetErrorExeption()
        {
            _serviceMock.Setup(x => x.GetChampionatsAsync())
                .ThrowsAsync(new Exception());

            var interactor = new ChampionatInteractor(_presenterMock.Object,
                _serviceMock.Object);

            _ = interactor.GetChampionatsAsync();

            _presenterMock.Verify(x => x.SetError(), "SetError должен быть вызван");
        }
    }
}