using dm.lib.core.nuget;
using dm.lib.infrastructure.nuget;
using Leo.Guided.Buy.Core.Entity;
using Leo.Guided.Buy.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leo.Guided.Buy.API.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventHandlerController : BaseController
    {
        private readonly IEventHandlerService _eventHandlerService;

        public EventHandlerController(IGepService gepService, IEventHandlerService eventHandlerService) : base(gepService)
        {
            _eventHandlerService = eventHandlerService;
        }

        [HttpPost("SubmitQuestionnaireResponse", Name = "SubmitQuestionnaireResponse")]
        public async Task<GepReturn<bool>> SubmitQuestionnaireResponse(SubmitQuestionnairePayload submitQuestionnairePayload)
        {
            try
            {
                return new GepReturn<bool>(await _eventHandlerService.SubmitQuestionnaireResponse(submitQuestionnairePayload));
            }
            catch (Exception ex)
            {
                LogError(GetClassName(), GetActionMethodName(), ex.Message, ex);
                return new GepReturn<bool>(new GepException(ex.Message, SeverityLevel.Critical, ex));
            }
        }

    }
}
