using dm.lib.core.nuget;
using dm.lib.infrastructure.nuget;
using Leo.Guided.Buy.API.Controllers;
using Leo.Guided.Buy.Core.Entity;
using Leo.Guided.Buy.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leo.Guided.Buy.Api.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionarieController : BaseController
    {
        private readonly IQuestionarieService _iquestionarieService;

        public QuestionarieController(IGepService gepService, IQuestionarieService questionarieService) : base(gepService)
        {
            _iquestionarieService = questionarieService;
        }

        [HttpGet("GetQuestionarie", Name = "GetQuestionarie")]
        public GepReturn<QuestionarieEntity> GetQuestionarie()
        {
            try
            {
                return new GepReturn<QuestionarieEntity>(_iquestionarieService.GetQuestionarie());
            }
            catch (Exception ex)
            {
                LogError(GetClassName(), GetActionMethodName(), ex.Message, ex);
                return new GepReturn<QuestionarieEntity>(new GepException(ex.Message, SeverityLevel.Critical, ex));
            }
        }
    }
}
