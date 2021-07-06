using dm.lib.core.nuget;
using Leo.Guided.Buy.Api.Test.TestData;
using Leo.Guided.Buy.API.Controllers.v1;
using Leo.Guided.Buy.Core.Entity;
using Leo.Guided.Buy.Service.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Leo.Guided.Buy.Api.Test.ControllerTestCases
{
    public class EventHandlerControllerTest
    {
        private readonly EventHandlerController _eventHandlerController;
        private readonly Mock<IEventHandlerService> _mockeventHandlerService;
        private readonly Mock<IGepService> _mockGepService;

        public EventHandlerControllerTest()
        {
            _mockGepService = new Mock<IGepService>();
            _mockeventHandlerService = new Mock<IEventHandlerService>();
            _eventHandlerController = new EventHandlerController(_mockGepService.Object, _mockeventHandlerService.Object);

        }

        [Fact]
        public void EventHandlerControllerData()
        {
            _mockeventHandlerService.Setup(x => x.SubmitQuestionnaireResponse(EventHandlerControllerTestData.eventHandlerControllers))
                //.Returns(EventHandlerControllerTestData.eventHandlerControllers);
                .ReturnsAsync(true);
            var result = _eventHandlerController.SubmitQuestionnaireResponse(EventHandlerControllerTestData.eventHandlerControllers);
             Assert.True(result.Result.ReturnValue);

            // result.Result.ReturnValue.Equals(EventHandlerControllerTestData.eventHandlerControllers);
            // Assert.Equal(QuestionarieControllerTestData.questionarieControllerslist, result.ReturnValue);
        }
        [Fact]
        public void EventHandlerControllerDataError()
        {
            _mockeventHandlerService.Setup(x => x.SubmitQuestionnaireResponse(EventHandlerControllerTestData.eventHandlerControllers))
                .Throws(new SystemException("Error"));
            var result = _eventHandlerController.SubmitQuestionnaireResponse(EventHandlerControllerTestData.eventHandlerControllers);
             result.Result.ErrorCode.Equals("Error");
          
            //  Assert.Equal("Error", result.Result.ErrorMessage);
            // Assert.Equal("ERROR", result.ErrorCode);
         
        }
    }
}
