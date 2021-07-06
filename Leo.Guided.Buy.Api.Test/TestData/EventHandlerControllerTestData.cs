using Leo.Guided.Buy.API.Controllers.v1;
using System;
using Leo.Guided.Buy.Core.Entity;
using System.Collections.Generic;
using System.Text;

namespace Leo.Guided.Buy.Api.Test.TestData
{
    class EventHandlerControllerTestData
    {

        public static SubmitQuestionnairePayload eventHandlerControllers = new SubmitQuestionnairePayload()
        {
            CategoryId = "1",
            CategoryName="dsdbc",
            Label="rqurh",
            Output="sdafn",
            Questions=new List<Question>()
            {
                new Question()
                {
                    QuestionId="dcsd",
                    QuestionText="sdnu",
                    Answer="rhwgr"
                }
            },

        };
      
    }
}
