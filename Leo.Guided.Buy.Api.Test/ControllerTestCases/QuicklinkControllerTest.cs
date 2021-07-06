using System;
using System.Collections.Generic;
using System.Text;
using dm.lib.core.nuget;
using FsCheck;
using Leo.Guided.Buy.Api.Controllers.v1;
using Leo.Guided.Buy.Api.Test.TestData;
using Leo.Guided.Buy.Service.Interface;
using Moq;
using Xunit;

namespace Leo.Guided.Buy.Api.Test
{
    public class QuicklinkControllerTest
    {
        private readonly QuicklinkController _quicklinkController;
        private readonly Mock<IQuicklinkService> _mockQuicklinkService;
        private readonly Mock<IGepService> _mockGepService;
        private readonly Mock<IGepLogger> _mockIGepLogger;

        public QuicklinkControllerTest()
        {
            _mockIGepLogger = new Mock<IGepLogger>();
            _mockGepService = new Mock<IGepService>();
            _mockQuicklinkService = new Mock<IQuicklinkService>();
            _quicklinkController = new QuicklinkController(_mockGepService.Object, _mockQuicklinkService.Object);
        }
        [Fact]
        public void GetQuicklinkMasterValue()
        {
            _mockQuicklinkService.Setup(x => x.GetQuicklinkMasterData()).
                ReturnsAsync(QuickLinkControllerTestData.quicklinks);
            var result = _quicklinkController.GetQuicklinkMasterData();
            Assert.Equal(QuickLinkControllerTestData.quicklinks, result.Result.ReturnValue);

            //_mockQuicklinkService.Setup(x => x.GetQuicklinkMasterData()).ReturnsAsync(TestData.TestData.QuicklikeMasterData);
            //var result = _quicklinkController.GetQuicklinkMasterData();
            //Assert.Equal(result.Result.ReturnValue, TestData.TestData.QuicklikeMasterData);
        }

        [Fact]
        public void GetQuicklinksMasterValueError()
        {
            _mockQuicklinkService.Setup(x => x.GetQuicklinkMasterData()).Throws(new SystemException("error"));
            _mockIGepLogger.Setup(x => x.LogError("cls", "getquicklinkmasterdata", "sdlcnjd", new SystemException("error"))).Verifiable();
            var result = _quicklinkController.GetQuicklinkMasterData();

            Assert.Equal("ERROR", result.Result.ErrorCode);

            //Assert.Equal("ERROR", result.Exception.Message);
            //Assert.Equal(result.Exception.Message, "ERROR");
        }

    }
}
