using dm.lib.core.nuget;
using Leo.Guided.Buy.Api.Controllers.v1;
using Leo.Guided.Buy.Service.Interface;
using System;
using Leo.Guided.Buy.Core.Entity;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Leo.Guided.Buy.Api.Test.TestData;


namespace Leo.Guided.Buy.Api.Test.TController_TestCases
{
    public class QuestionarieControllerTest
    {
        private readonly QuestionarieController _questionarecontroller;
        private readonly Mock<IQuestionarieService> _mockQuestionareServics;
        private readonly Mock<IGepService> _mockGepService;


        public QuestionarieControllerTest()
        {
            _mockGepService = new Mock<IGepService>();
            _mockQuestionareServics = new Mock<IQuestionarieService>();
            _questionarecontroller = new QuestionarieController(_mockGepService.Object, _mockQuestionareServics.Object);
        }


        [Fact]
        public void Getquestionariedata()
        {
            _mockQuestionareServics.Setup(x => x.GetQuestionarie()).
                Returns(QuestionarieControllerTestData.questionarieControllerslist);
            var result = _questionarecontroller.GetQuestionarie();
            Assert.Equal(QuestionarieControllerTestData.questionarieControllerslist, result.ReturnValue);
        }

        [Fact]
        public void GetQuestionarieDataError()
        {
            _mockQuestionareServics.Setup(x => x.GetQuestionarie()).Throws(new SystemException("ERROR"));
            var result = _questionarecontroller.GetQuestionarie();
            Assert.Equal("ERROR", result.ErrorCode);
        }
    }
}
