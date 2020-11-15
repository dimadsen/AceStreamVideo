using System.Collections.Generic;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchPreviewModule;
using AceStream.Services;
using AceStream.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace AceStream.iOS.Modules.Tests
{
    public class MatchPreviewTests
    {
        Mock<IMatchPreviewPresenter> _presenterMock;
        Mock<IMatchPreviewService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _presenterMock = new Mock<IMatchPreviewPresenter>();
            _serviceMock = new Mock<IMatchPreviewService>();
        }

        [Test]
        public void Interactor_MatchesNotFoundNull()
        {
            var championatId = It.IsAny<int>();
            
            _serviceMock.Setup(x => x.GetMatchesAsync(championatId))
                .ReturnsAsync(() => null);

            var interactor = new MatchPreviewInteractor(_presenterMock.Object,
                _serviceMock.Object);

            _ = interactor.GetMatchesAsync(championatId);

            _presenterMock.Verify(x => x.SetNotFoundMatches(It.IsAny<string>()), "SetNotFoundMatches должен быть вызван");
        }

        [Test]
        public void Interactor_MatchesNotFoundEmpty()
        {
            var championatId = It.IsAny<int>();

            _serviceMock.Setup(x => x.GetMatchesAsync(championatId))
                .ReturnsAsync(() => new List<MatchPreviewDto>());

            var interactor = new MatchPreviewInteractor(_presenterMock.Object,
                _serviceMock.Object);

            _ = interactor.GetMatchesAsync(championatId);

            _presenterMock.Verify(x => x.SetNotFoundMatches(It.IsAny<string>()), "SetNotFoundMatches должен быть вызван");
        }
    }
}
